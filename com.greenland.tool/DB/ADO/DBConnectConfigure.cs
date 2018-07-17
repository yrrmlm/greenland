using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.DB.ADO
{
    public class DBConnectConfigure
    {
        private static DBConnectConfigure _instance = null;

        private static readonly object SynObject = new object();

        private string serverIp;

        private int serverPort;

        private string connectName;

        private string connectPwd;

        private string dataBase;

        private string connectString;

        protected string ServerIp
        {
            get { return serverIp; }
            set { }
        }

        protected int ServerPort
        {
            get { return serverPort < 0 ? 3306 : serverPort; }
            set { }
        }

        protected string ConnectName
        {
            get { return connectName ?? "liumin"; }
            set { }
        }

        protected string ConnectPwd
        {
            get { return connectPwd ?? "liumin@123"; }
            set { }
        }

        protected string DataBase
        {
            get { return dataBase; }
            set { }
        }

        public DBConnectConfigure()
        {

        }

        public DBConnectConfigure(string connectString)
        {
            this.connectString = connectString;
        }

        public DBConnectConfigure(string serverIp,int serverPort,string connectName,string connectPwd,string dataBase)
        {
            this.serverIp = serverIp;
            this.serverPort = serverPort;
            this.connectName = connectName;
            this.connectPwd = connectPwd;
            this.dataBase = dataBase;
        }

        public string GetConnectString()
        {
            if (string.IsNullOrWhiteSpace(this.connectString))
            {
                return string.Format("server={0};port={1};database={2};user id ={3};password={4};Allow Zero Datetime = true",
                    serverIp, serverPort, connectName, connectPwd,dataBase);
            }
            else
            {
                return connectString;
            }
        }

        public static DBConnectConfigure Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SynObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new DBConnectConfigure();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
