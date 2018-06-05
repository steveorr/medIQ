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
    public class Error_LogController : ApiController
    {
        private Med_IQ_Context db = new Med_IQ_Context();

        // GET: api/Error_Log
        public IQueryable<Error_Log> GetError_Log()
        {
            return db.Error_Log;
        }

        // GET: api/Error_Log/5
        [ResponseType(typeof(Error_Log))]
        public IHttpActionResult GetError_Log(int id)
        {
            Error_Log error_Log = db.Error_Log.Find(id);
            if (error_Log == null)
            {
                return NotFound();
            }

            return Ok(error_Log);
        }

        // PUT: api/Error_Log/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutError_Log(int id, Error_Log error_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != error_Log.Id)
            {
                return BadRequest();
            }

            db.Entry(error_Log).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Error_LogExists(id))
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

        // POST: api/Error_Log
        [ResponseType(typeof(Error_Log))]
        public IHttpActionResult PostError_Log(Error_Log error_Log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Error_Log.Add(error_Log);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = error_Log.Id }, error_Log);
        }

        // DELETE: api/Error_Log/5
        [ResponseType(typeof(Error_Log))]
        public IHttpActionResult DeleteError_Log(int id)
        {
            Error_Log error_Log = db.Error_Log.Find(id);
            if (error_Log == null)
            {
                return NotFound();
            }

            db.Error_Log.Remove(error_Log);
            db.SaveChanges();

            return Ok(error_Log);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Error_LogExists(int id)
        {
            return db.Error_Log.Count(e => e.Id == id) > 0;
        }
    }
}