using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ServiceRecruimentEntity.Models;

namespace ServiceRecruimentEntity.Controllers
{
    public class RecruimentController : ApiController
    {
        private RecruimentEntities db = new RecruimentEntities();

        // GET api/Recruiment
        public IQueryable<TTUT> GetTTUTs()
        {
            return db.TTUTs;
        }

        // GET api/Recruiment/5
        [ResponseType(typeof(TTUT))]
        public IHttpActionResult GetTTUT(int id)
        {
            TTUT ttut = db.TTUTs.Find(id);
            if (ttut == null)
            {
                return NotFound();
            }

            return Ok(ttut);
        }

        // PUT api/Recruiment/5
        public IHttpActionResult PutTTUT(int id, TTUT ttut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ttut.ID)
            {
                return BadRequest();
            }

            db.Entry(ttut).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTUTExists(id))
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

        // POST api/Recruiment
        [ResponseType(typeof(TTUT))]
        public IHttpActionResult PostTTUT(TTUT ttut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTUTs.Add(ttut);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ttut.ID }, ttut);
        }

        // DELETE api/Recruiment/5
        [ResponseType(typeof(TTUT))]
        public IHttpActionResult DeleteTTUT(int id)
        {
            TTUT ttut = db.TTUTs.Find(id);
            if (ttut == null)
            {
                return NotFound();
            }

            db.TTUTs.Remove(ttut);
            db.SaveChanges();

            return Ok(ttut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTUTExists(int id)
        {
            return db.TTUTs.Count(e => e.ID == id) > 0;
        }
    }
}