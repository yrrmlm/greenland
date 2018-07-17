

using NHibernate;
using NHibernate.Cfg;
/**
* 命名空间: com.greenland.tool.DB.NHibernate
*
* 功 能： N/A
* 类 名： GetSessionFactory
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/7/17 15:52:25 liumin 初版
*
* Copyright (c) 2018 Lir Corporation. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.DB.NHibernate
{
    public class HibnernatHelper<T>
    {
        private static readonly object lockobj = new object();

        private static ISessionFactory sessionFactory;

        public HibnernatHelper()
        {
            if (sessionFactory == null)
            {
                lock (lockobj)
                {
                    sessionFactory = new Configuration().Configure().BuildSessionFactory();
                }
            }
        }

        public ISession GetSession()
        {
            return sessionFactory.OpenSession();
        }

        public int Create(T entity)
        {
            using (ISession session = GetSession())
            {
                int newId = (int)(session.Save(entity));
                session.Flush();
                session.Close();
                return newId;
            }
        }

        public bool Delete(string sql)
        {
            using (ISession session = GetSession())
            {
                IQuery query = session.CreateQuery(sql);             
                int affectedRows = query.ExecuteUpdate();
                session.Close();
                return affectedRows > 0;
            }
        }

        public void Update(T entity)
        {
            using (ISession session = GetSession())
            {
                session.Update(entity);
                session.Flush();
                session.Close();
            }
        }   
    }
}
