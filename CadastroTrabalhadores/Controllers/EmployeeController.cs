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
using CadastroTrabalhadores.Models;

namespace CadastroTrabalhadores.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeModel db = new EmployeeModel();

        // GET: api/Employee
        public IQueryable<TRABALHADOR> GetTRABALHADORs()
        {
            return db.TRABALHADORs;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(TRABALHADOR))]
        public IHttpActionResult GetTRABALHADOR(int id)
        {
            TRABALHADOR tRABALHADOR = db.TRABALHADORs.Find(id);
            if (tRABALHADOR == null)
            {
                return NotFound();
            }

            return Ok(tRABALHADOR);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRABALHADOR(int id, TRABALHADOR tRABALHADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRABALHADOR.cd_trabalhador)
            {
                return BadRequest();
            }

            db.Entry(tRABALHADOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRABALHADORExists(id))
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

        // POST: api/Employee
        [ResponseType(typeof(TRABALHADOR))]
        public IHttpActionResult PostTRABALHADOR(TRABALHADOR tRABALHADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TRABALHADORs.Add(tRABALHADOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tRABALHADOR.cd_trabalhador }, tRABALHADOR);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(TRABALHADOR))]
        public IHttpActionResult DeleteTRABALHADOR(int id)
        {
            TRABALHADOR tRABALHADOR = db.TRABALHADORs.Find(id);
            if (tRABALHADOR == null)
            {
                return NotFound();
            }

            db.TRABALHADORs.Remove(tRABALHADOR);
            db.SaveChanges();

            return Ok(tRABALHADOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRABALHADORExists(int id)
        {
            return db.TRABALHADORs.Count(e => e.cd_trabalhador == id) > 0;
        }
    }
}