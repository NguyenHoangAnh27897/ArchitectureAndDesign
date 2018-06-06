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
using ServiceHumanResourceEntity.Models;

namespace ServiceHumanResourceEntity.Controllers
{
    public class HumanResourceController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET api/HumanResource
        public IQueryable<TTNV> GetTTNVs()
        {
            return db.TTNVs;
        }

        // GET api/HumanResource/5
        [ResponseType(typeof(TTNV))]
        public IHttpActionResult GetTTNV(string id)
        {
            TTNV ttnv = db.TTNVs.Find(id);
            if (ttnv == null)
            {
                return NotFound();
            }

            return Ok(ttnv);
        }

        // PUT api/HumanResource/5
        public IHttpActionResult PutTTNV(string id, TTNV ttnv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ttnv.ID)
            {
                return BadRequest();
            }

            db.Entry(ttnv).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTNVExists(id))
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

        // POST api/HumanResource
        [ResponseType(typeof(TTNV))]
        public IHttpActionResult PostTTNV(TTNV ttnv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTNVs.Add(ttnv);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TTNVExists(ttnv.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ttnv.ID }, ttnv);
        }

        // DELETE api/HumanResource/5
        [ResponseType(typeof(TTNV))]
        public IHttpActionResult DeleteTTNV(string id)
        {
            TTNV ttnv = db.TTNVs.Find(id);
            if (ttnv == null)
            {
                return NotFound();
            }

            db.TTNVs.Remove(ttnv);
            db.SaveChanges();

            return Ok(ttnv);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTNVExists(string id)
        {
            return db.TTNVs.Count(e => e.ID == id) > 0;
        }
    }
}