using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using NHibernate.Linq;
using ServiceHumanResourceNhibernate.Models.NHibernate;

namespace ServiceHumanResourceNhibernate.Controllers
{
    public class AccountController : ApiController
    {
        public IEnumerable<DSTK> GetDSTKs()
        {
            using (ISession session = NHibernateSession.OpenSessionACC())
            {
                var dstk = session.Query<DSTK>().ToList();
                return dstk;
            }
        }

        [HttpPost]
        public IHttpActionResult CheckAccount(string username, string pass)
        {
            using (ISession session = NHibernateSession.OpenSessionACC())
            {
                var ch = session.Query<DSTK>().ToList();
                foreach (var item in ch)
                {
                    if (item.UserName.Equals(username))
                    {
                        if (item.Password.Equals(pass))
                        {
                            return Json(new { msg = "Thanh Cong" });
                        }
                        else
                        {
                            return Json(new { msg = "User hoặc Pass bị sai" });
                        }
                    }
                }
                return Json(new { msg = "User hoặc Pass bị sai" });
            }
        }
    }
}
