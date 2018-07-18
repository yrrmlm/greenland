

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

namespace com.greenland.dataaccess.Admin
{
    public class UserAccess : BaseAccess<UserEntity>
    {
        public const string TableName = "gl_users";

        public const string Columns = " id,loginname,loginpwd,pwdsalt,isactive,createtime,createby,updatetime,updateby ";

        public List<UserEntity> AllUsers()
        {
            var sql = string.Format("select {0} from {1} where isdelete = 0", Columns, TableName);
            var dt = MySqlHelper.ExcuteDT(sql);
            if(dt != null && dt.Rows.Count > 0)
            {
                return ConvertToEntityList(dt);
            }

            return null;
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
