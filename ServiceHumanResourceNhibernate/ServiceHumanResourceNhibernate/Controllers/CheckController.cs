using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using ServiceHumanResourceNhibernate.Models.NHibernate;

namespace ServiceHumanResourceNhibernate.Controllers
{
    public class CheckController : Controller
    {
        //
        // GET: /Check/
        [HttpPost]
        public ActionResult CheckAccount(string username, string pass)
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
                            return Json(new { msg = "Thanh Cong", accept = true });
                        }
                        else
                        {
                            return Json(new { msg = "User hoặc Pass bị sai", accept = false });
                        }
                    }
                }
                return Json(new { msg = "User hoặc Pass bị sai", accept = false });
            }
        }
	}
}