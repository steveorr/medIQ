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
    public class ProceduresController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Procedures
        public IQueryable<Procedures> GetProcedures()
        {
            return db.Procedures;
        }

        // GET: api/Procedures/5
        [ResponseType(typeof(Procedures))]
        public IHttpActionResult GetProcedures(int id)
        {
            Procedures procedures = db.Procedures.Find(id);
            if (procedures == null)
            {
                return NotFound();
            }

            return Ok(procedures);
        }

        // PUT: api/Procedures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProcedures(int id, Procedures procedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedures.Id)
            {
                return BadRequest();
            }

            db.Entry(procedures).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProceduresExists(id))
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

        // POST: api/Procedures
        [ResponseType(typeof(Procedures))]
        public IHttpActionResult PostProcedures(Procedures procedures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Procedures.Add(procedures);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = procedures.Id }, procedures);
        }

        // DELETE: api/Procedures/5
        [ResponseType(typeof(Procedures))]
        public IHttpActionResult DeleteProcedures(int id)
        {
            Procedures procedures = db.Procedures.Find(id);
            if (procedures == null)
            {
                return NotFound();
            }

            db.Procedures.Remove(procedures);
            db.SaveChanges();

            return Ok(procedures);
        }

        [Route("api/Procedures/Search/{typeid}/{insurerid}/{procdate}/{email}")]
        [HttpGet]
        [ResponseType(typeof(Procedures))]
        public IHttpActionResult Search(int typeid, int insurerid, DateTime procdate, string email)
        {
            var procedures = db.Procedures.Where(p => p.ProcedureTypeID == typeid || p.InsurerID == insurerid || p.ProcedureDate == procdate || p.PatientEmail == email );

            if (procedures == null)
            {
                return NotFound();
            }

            return Ok(procedures);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProceduresExists(int id)
        {
            return db.Procedures.Count(e => e.Id == id) > 0;
        }
    }
}