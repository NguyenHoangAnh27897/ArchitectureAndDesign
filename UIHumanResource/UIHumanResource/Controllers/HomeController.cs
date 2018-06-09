using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

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
        public ActionResult ResumeDetail(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail()
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("shuu27897@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("hoanganh27897@gmail.com");  // replace with valid value
            message.Subject = "Xác nhận đơn ứng tuyển";
            message.Body = string.Format(body, "Phòng Tổ chức nhân sự", "hoanganh27897@gmail.com", "Xác nhận đơn ứng tuyển, bạn sẽ phỏng vấn vào ngày mai");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "hoanganh27897@gmail.com",  // replace with valid value
                    Password = "pokemonblackwhite2"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return View("ViewList");
            }
        }  
    }
}