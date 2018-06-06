using ServiceHumanResourceEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceHumanResourceEntity.Controllers
{
    public class CheckController : Controller
    {

        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: Check
        [HttpPost]
        public ActionResult CheckAccount(string username, string pass)
        {
            var ch = db.DSTKs.ToList();
            foreach (var item in ch)
            {
                if (item.User_Name.Equals(username))
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