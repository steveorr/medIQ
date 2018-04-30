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
    public class Procedure_TypesController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Procedure_Types
        public IQueryable<Procedure_Types> GetProcedure_Types()
        {
            return db.Procedure_Types;
        }

        // GET: api/Procedure_Types/5
        [ResponseType(typeof(Procedure_Types))]
        public IHttpActionResult GetProcedure_Types(int id)
        {
            Procedure_Types procedure_Types = db.Procedure_Types.Find(id);
            if (procedure_Types == null)
            {
                return NotFound();
            }

            return Ok(procedure_Types);
        }

        // PUT: api/Procedure_Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProcedure_Types(int id, Procedure_Types procedure_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedure_Types.Id)
            {
                return BadRequest();
            }

            db.Entry(procedure_Types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Procedure_TypesExists(id))
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

        // POST: api/Procedure_Types
        [ResponseType(typeof(Procedure_Types))]
        public IHttpActionResult PostProcedure_Types(Procedure_Types procedure_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Procedure_Types.Add(procedure_Types);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = procedure_Types.Id }, procedure_Types);
        }

        // DELETE: api/Procedure_Types/5
        [ResponseType(typeof(Procedure_Types))]
        public IHttpActionResult DeleteProcedure_Types(int id)
        {
            Procedure_Types procedure_Types = db.Procedure_Types.Find(id);
            if (procedure_Types == null)
            {
                return NotFound();
            }

            db.Procedure_Types.Remove(procedure_Types);
            db.SaveChanges();

            return Ok(procedure_Types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Procedure_TypesExists(int id)
        {
            return db.Procedure_Types.Count(e => e.Id == id) > 0;
        }
    }
}