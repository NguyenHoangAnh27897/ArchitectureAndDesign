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
        public ActionResult AddResume(string fullname, string email, string phonenumber, string doa, string dob, string applyposition, string file)
        {

            DateTime myDate = DateTime.Parse(doa); //Parse string => DateTime


            //var list = new TTUT
            //{
            //    FullName = fullname,
            //    DayofBirth = doa,
            //    PhoneNumber = phonenumber,
            //    Email = email,
            //    ApplyPosition = applyposition,
            //    DateofApplication = dob,
            //    FileAttach = file
            //};
            //db.TTUTs.Add(list);
            //db.SaveChanges();


            return Json(new { msg = "Đăng ký ứng tuyển thành công", accept = true });
        }
	}
}