using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using ServiceHumanResourceEntity.Models;

namespace ServiceHumanResourceEntity.Controllers
{
    public class AccountController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET api/Account
        public IQueryable<DSTK> GetDSTKs()
        {
            return db.DSTKs;
        }

        // GET api/Account/5
        [ResponseType(typeof(DSTK))]
        public IHttpActionResult GetDSTK(int id)
        {
            DSTK dstk = db.DSTKs.Find(id);
            if (dstk == null)
            {
                return NotFound();
            }

            return Ok(dstk);
        }

        // PUT api/Account/5
        public IHttpActionResult PutDSTK(int id, DSTK dstk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dstk.ID)
            {
                return BadRequest();
            }

            db.Entry(dstk).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DSTKExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Account
        [ResponseType(typeof(DSTK))]
        public IHttpActionResult PostDSTK(DSTK dstk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DSTKs.Add(dstk);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dstk.ID }, dstk);
        }

        // DELETE api/Account/5
        [ResponseType(typeof(DSTK))]
        public IHttpActionResult DeleteDSTK(int id)
        {
            DSTK dstk = db.DSTKs.Find(id);
            if (dstk == null)
            {
                return NotFound();
            }

            db.DSTKs.Remove(dstk);
            db.SaveChanges();

            return Ok(dstk);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DSTKExists(int id)
        {
            return db.DSTKs.Count(e => e.ID == id) > 0;
        }
        [HttpPost]
        public IHttpActionResult CheckAccount(string json)
        {
            dynamic data = JObject.Parse(json);
            var ch = db.DSTKs.ToList();
            foreach (var item in ch)
            {
                if (item.User_Name.Equals(data.username))    
                {
                    if (item.Password.Equals(data.pass))
                    {
                        return Json(new {msg="Thanh Cong"});
                    }
                    else
                    {
                       return Json(new {msg="Thanh Cong"});
                    }
                }
            }
            return Json(new { msg = "Thanh Cong" });
        }
    }
}