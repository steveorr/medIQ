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
using Med_IQ.Models;

namespace Med_IQ.Controllers
{
    public class DoctorsController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Doctors
        public IQueryable<Doctors> GetDoctors()
        {
            return db.Doctors;
        }

        // GET: api/Doctors/5
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult GetDoctors(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        }

        // PUT: api/Doctors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctors(int id, Doctors doctors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctors.Id)
            {
                return BadRequest();
            }

            db.Entry(doctors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(id))
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

        // POST: api/Doctors
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult PostDoctors(Doctors doctors)
        {
            if (!ModelState.IsValid)
            {
                ErrorLog_Helper.LogError("Bad Model State - PostDoctors", "public IHttpActionResult PostDoctors(Doctors doctors)");
                return BadRequest(ModelState);
            }

            db.Doctors.Add(doctors);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DoctorsExists(doctors.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doctors.Id }, doctors);
        }

        // DELETE: api/Doctors/5
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult DeleteDoctors(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return NotFound();
            }

            db.Doctors.Remove(doctors);
            db.SaveChanges();

            return Ok(doctors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return db.Doctors.Count(e => e.Id == id) > 0;
        }
    }
}