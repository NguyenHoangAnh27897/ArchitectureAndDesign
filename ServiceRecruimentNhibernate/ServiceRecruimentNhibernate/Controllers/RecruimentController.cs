using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using NHibernate;
using NHibernate.Linq;
using System.Web.Http;
using ServiceRecruimentNhibernate.Models.NHibernate;

namespace ServiceRecruimentNhibernate.Controllers
{
    public class RecruimentController : ApiController
    {
        public IEnumerable<TTUT> GetTTUTs()
        {
            using (ISession session = NHIbernateSession.OpenSession())
            {
                var ttut = session.Query<TTUT>().ToList();
                return ttut;
            }
        }
    }
}
