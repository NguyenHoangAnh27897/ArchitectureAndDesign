using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIHumanResource.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult ViewList()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult ViewListEmployers()
        {
            return View();
        }
        public ActionResult ResumeDetail()
        {
            return View();
        }
    }
}