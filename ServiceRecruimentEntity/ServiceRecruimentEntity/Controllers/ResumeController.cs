using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceRecruimentEntity.Models;
using System.Globalization;

namespace ServiceRecruimentEntity.Controllers
{
    public class ResumeController : Controller
    {
        private RecruimentEntities db = new RecruimentEntities();
        //
        // GET: /Resume/
        [HttpPost]
        public ActionResult AddResume(string username, string email, string phone, string birthday, string position, string FileAttach)
        {

            //DateTime myDate = DateTime.ParseExact(birthday, "yyyy-MM-dd", CultureInfo.InvariantCulture); //Parse string => DateTime

            var list = new TTUT
            {
                FullName = username,
                PhoneNumber = phone,
                DayofBirth = DateTime.Now,
                Email = email,
                ApplyPosition = position,
                DateofApplication = DateTime.Now,
                FileAttach = FileAttach
            };
            db.TTUTs.Add(list);
            db.SaveChanges();


            return Json(new { msg = "Đăng ký ứng tuyển thành công", accept = true });
        }
	}
}