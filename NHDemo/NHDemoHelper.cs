using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHDemo
{
    public sealed class NHDemoHelper
    {
        private static readonly ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();

        private static readonly ISession currentSession = sessionFactory.OpenSession();

        private NHDemoHelper()
        {
        }

        public static ISession GetCurrentSession()
        {
            return currentSession;
        }

        public static void CloseSession()
        {
            currentSession.Close();
            if (sessionFactory != null)
                sessionFactory.Close();
        }
    }
}