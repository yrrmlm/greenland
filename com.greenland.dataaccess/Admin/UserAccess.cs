

using com.greenland.entity.User;
/**
* 命名空间: com.greenland.dataaccess.Admin
*
* 功 能： 用户访问类
* 类 名： UserAccess
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 13:23:00 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using com.greenland.tool.Extension;
using MySql.Data.MySqlClient;
using MySqlHelper = com.greenland.tool.DB.ADO.MySqlHelper;
using com.greenland.model.AdminModel.Request.User;

namespace com.greenland.dataaccess.Admin
{
    public class UserAccess : BaseAccess<UserEntity>
    {
        public const string TableName = "gl_users";

        public const string Columns = " id,loginname,loginpwd,pwdsalt,isactive,createtime,createby,updatetime,updateby ";

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<UserEntity> AllUsers(UserListReq request,out int totalCount)
        {
            totalCount = 0;
            var sql = string.Format("select SQL_CALC_FOUND_ROWS {0} from {1} where isdelete = 0", Columns, TableName);
            var parameters = new List<MySqlParameter>();
            if(!string.IsNullOrWhiteSpace(request.searchWord))
            {
                sql += string.Format(" and loginname LIKE CONCAT('%',@loginname,'%')");
                parameters.Add(new MySqlParameter("@loginname", request.searchWord));
            }


            sql += string.Format(" limit {0},{1};", (request.pageIndex - 1) * request.pageSize, request.pageSize);

            sql += string.Format("select found_rows();", TableName);
            var ds = MySqlHelper.ExcuteDS(sql,parameters);
            if(ds != null && ds.Tables != null && ds.Tables.Count > 0 )
            {
                totalCount = ds.Tables[1].Rows[0][0].ToInt();
                return ConvertToEntityList(ds.Tables[0]);
            }

            return null;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool RemoveUser(int userId)
        {
            var sql = string.Format("update {0} set isdelete = 1 where id = @id", TableName);
            var parameters = new List<MySqlParameter> { new MySqlParameter("@id", userId) };
            return MySqlHelper.ExcuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserEntity user)
        {
            var sql = string.Format("update {0} set loginname = @loginname,loginpwd = @loginpwd,updateby = @updateby,updatetime = @updatetime where id = @id", TableName);
            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@loginname", user.Loginname),
                new MySqlParameter("@loginpwd", user.Loginpwd),
                new MySqlParameter("@updateby", user.Updateby ?? string.Empty),
                new MySqlParameter("@updatetime", DateTime.Now),
                new MySqlParameter("@id",user.Id)
            };
            return MySqlHelper.ExcuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(UserEntity user)
        {
            var sql = string.Format("insert into {0}(loginname,loginpwd,pwdsalt,isactive,createby,createtime,updateby,updatetime)values(@loginname,@loginpwd,@pwdsalt,@isactive,@createby,@createtime,@updateby,@updatetime)", TableName);
            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@loginname", user.Loginname),
                new MySqlParameter("@loginpwd", user.Loginpwd),
                new MySqlParameter("@pwdsalt", user.Pwdsalt ?? string.Empty),
                new MySqlParameter("@isactive", 1),
                new MySqlParameter("@createby", user.Createby ?? string.Empty),
                new MySqlParameter("@createtime", DateTime.Now),
                new MySqlParameter("@updateby", user.Updateby ?? string.Empty),
                new MySqlParameter("@updatetime", DateTime.Now)
            };
            return MySqlHelper.ExcuteNonQuery(sql, parameters);
        }

        protected override UserEntity ConvertToEntity(DataRow dr)
        {
            return new UserEntity
            {
                Id = dr["id"].ToInt(),
                Loginname = dr["loginname"].ToString(),
                Loginpwd = dr["loginpwd"].ToString(),
                Pwdsalt = dr["pwdsalt"].ToString(),
                Isactive = dr["isactive"].ToInt(),
                Createby = dr["createby"].ToString(),
                Createtime = dr["createtime"].ToDateTime(),
                Updateby = dr["updateby"].ToString(),
                Updatetime = dr["updatetime"].ToDateTime()
            };
        }

        protected override List<UserEntity> ConvertToEntityList(DataTable dt)
        {
            if(dt == null || dt.Rows == null || dt.Rows.Count == 0)
            {
                return null;
            }

            var list = new List<UserEntity>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(ConvertToEntity(dr));
            }

            return list;
        }
    }
}
