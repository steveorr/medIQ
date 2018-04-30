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
    public class Medical_FacilityController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Medical_Facility
        public IQueryable<Medical_Facility> GetMedical_Facility()
        {
            return db.Medical_Facility;
        }

        // GET: api/Medical_Facility/5
        [ResponseType(typeof(Medical_Facility))]
        public IHttpActionResult GetMedical_Facility(int id)
        {
            Medical_Facility medical_Facility = db.Medical_Facility.Find(id);
            if (medical_Facility == null)
            {
                return NotFound();
            }

            return Ok(medical_Facility);
        }

        // PUT: api/Medical_Facility/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedical_Facility(int id, Medical_Facility medical_Facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medical_Facility.Id)
            {
                return BadRequest();
            }

            db.Entry(medical_Facility).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Medical_FacilityExists(id))
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

        // POST: api/Medical_Facility
        [ResponseType(typeof(Medical_Facility))]
        public IHttpActionResult PostMedical_Facility(Medical_Facility medical_Facility)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medical_Facility.Add(medical_Facility);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medical_Facility.Id }, medical_Facility);
        }

        // DELETE: api/Medical_Facility/5
        [ResponseType(typeof(Medical_Facility))]
        public IHttpActionResult DeleteMedical_Facility(int id)
        {
            Medical_Facility medical_Facility = db.Medical_Facility.Find(id);
            if (medical_Facility == null)
            {
                return NotFound();
            }

            db.Medical_Facility.Remove(medical_Facility);
            db.SaveChanges();

            return Ok(medical_Facility);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Medical_FacilityExists(int id)
        {
            return db.Medical_Facility.Count(e => e.Id == id) > 0;
        }
    }
}