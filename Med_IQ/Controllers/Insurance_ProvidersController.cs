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
    public class Insurance_ProvidersController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Insurance_Providers
        public IQueryable<Insurance_Providers> GetInsurance_Providers()
        {
            return db.Insurance_Providers;
        }

        // GET: api/Insurance_Providers/5
        [ResponseType(typeof(Insurance_Providers))]
        public IHttpActionResult GetInsurance_Providers(int id)
        {
            Insurance_Providers insurance_Providers = db.Insurance_Providers.Find(id);
            if (insurance_Providers == null)
            {
                return NotFound();
            }

            return Ok(insurance_Providers);
        }

        // PUT: api/Insurance_Providers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurance_Providers(int id, Insurance_Providers insurance_Providers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance_Providers.Id)
            {
                return BadRequest();
            }

            db.Entry(insurance_Providers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Insurance_ProvidersExists(id))
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

        // POST: api/Insurance_Providers
        [ResponseType(typeof(Insurance_Providers))]
        public IHttpActionResult PostInsurance_Providers(Insurance_Providers insurance_Providers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurance_Providers.Add(insurance_Providers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = insurance_Providers.Id }, insurance_Providers);
        }

        // DELETE: api/Insurance_Providers/5
        [ResponseType(typeof(Insurance_Providers))]
        public IHttpActionResult DeleteInsurance_Providers(int id)
        {
            Insurance_Providers insurance_Providers = db.Insurance_Providers.Find(id);
            if (insurance_Providers == null)
            {
                return NotFound();
            }

            db.Insurance_Providers.Remove(insurance_Providers);
            db.SaveChanges();

            return Ok(insurance_Providers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Insurance_ProvidersExists(int id)
        {
            return db.Insurance_Providers.Count(e => e.Id == id) > 0;
        }
    }
}