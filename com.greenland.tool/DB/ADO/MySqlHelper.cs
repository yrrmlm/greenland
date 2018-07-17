using com.greenland.tool.BizException;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace com.greenland.tool.DB.ADO
{
    public class MySqlHelper
    { 
        private static string connectString = ConfigurationManager.AppSettings["SqlConnectString"].ToString();        
        private static DBConnectConfigure connectConfigure = new DBConnectConfigure(connectString);

        public static bool ExcuteNonQuery(string commandText, List<MySqlParameter> parameters = null)
        {
            return ExcuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public static bool ExcuteNonQuery(string commandText,CommandType commandType = CommandType.Text, List<MySqlParameter> parameters = null)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new ParameterNullOrEmptyException("数据库执行语句为空");
            }
            var result = -1;

            try
            {
                var conString = connectConfigure.GetConnectString();
                using (var connection = new MySqlConnection(conString))
                {
                    using (var sqlCommand = connection.CreateCommand())
                    {
                        connection.Open();
                        sqlCommand.CommandText = commandText;
                        sqlCommand.CommandType = commandType;
                        if (parameters != null && parameters.Count > 0)
                        {
                            for (int i = 0; i < parameters.Count; i++)
                                sqlCommand.Parameters.Add(parameters[i]);
                        }
                        result = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Parameters.Clear();
                        connection.Close();
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return result > 0;
        }

        public static DataSet ExcuteDS(string commandText, List<MySqlParameter> parameters = null)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new ParameterNullOrEmptyException("数据库执行语句为空");
            }

            DataSet ds = new DataSet();

            try
            {
                using (var connection = new MySqlConnection(connectConfigure.GetConnectString()))
                {                   
                    using (var sqlCommand = connection.CreateCommand())
                    {
                        connection.Open();
                        sqlCommand.CommandText = commandText;
                        if (parameters != null && parameters.Count > 0)
                        {
                            for (int i = 0; i < parameters.Count; i++)
                                sqlCommand.Parameters.Add(parameters[i]);
                        }
                        using (var adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = sqlCommand;
                            adapter.Fill(ds);
                            sqlCommand.Parameters.Clear();                          
                        }
                        connection.Close();
                    }                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return ds;
        }

        public static DataTable ExcuteDT(string commandText, List<MySqlParameter> parameters = null)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new ParameterNullOrEmptyException("数据库执行语句为空");
            }

            DataTable dt = null;

            try
            {
                var ds = ExcuteDS(commandText, parameters);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return dt;
        }
    }
}
