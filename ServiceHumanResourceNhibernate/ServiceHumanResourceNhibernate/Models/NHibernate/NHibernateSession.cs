using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace ServiceHumanResourceNhibernate.Models.NHibernate
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\TTNV.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public static ISession OpenSessionACC()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\DSTK.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}