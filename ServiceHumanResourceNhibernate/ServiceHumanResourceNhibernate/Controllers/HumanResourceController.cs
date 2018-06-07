using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NHibernate;
using NHibernate.Linq;
using System.Net.Http;
using System.Web.Http;
using ServiceHumanResourceNhibernate.Models.NHibernate;

namespace ServiceHumanResourceNhibernate.Controllers
{
    public class HumanResourceController : ApiController
    {
        public IEnumerable<TTNV> GetTTNVs()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var ttnv = session.Query<TTNV>().ToList();
                return ttnv;
            }
        }
    }
}
