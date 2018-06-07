using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceRecruimentEntity.Models;

namespace ServiceRecruimentEntity.Controllers
{
    public class ResumeController : Controller
    {
        private RecruimentEntities db = new RecruimentEntities();
        //
        // GET: /Resume/
        [HttpPost]
        public ActionResult AddResume(string fullname, string phonenumber, DateTime dob, string email, string applyposition, string file, DateTime doa)
        {
            var list = new TTUT
            {
                FullName = fullname,
                DayofBirth = dob,
                PhoneNumber = phonenumber,
                Email = email,
                ApplyPosition = applyposition,
                DateofApplication = doa,
                FileAttach = file
            };
            db.TTUTs.Add(list);
            db.SaveChanges();

            return Json(new { msg = "Đăng ký ứng tuyển thành công", accept = true });
        }
	}
}