using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MobileSAPSAPI.Models;

namespace MobileSAPSAPI.Controllers
{
    public class TrafficViolationsController : ApiController
    {
        private MobileSAPSAPIContext db = new MobileSAPSAPIContext();

        // GET: api/TrafficViolations
        public IQueryable<TrafficViolations> GetTrafficFineModels()
        {
            return db.TrafficFineModels;
        }

        // GET: api/TrafficViolations/5
        [ResponseType(typeof(TrafficViolations))]
        public async Task<IHttpActionResult> GetTrafficViolations(int id)
        {
            TrafficViolations trafficViolations = await db.TrafficFineModels.FindAsync(id);
            if (trafficViolations == null)
            {
                return NotFound();
            }

            return Ok(trafficViolations);
        }

        // PUT: api/TrafficViolations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrafficViolations(int id, TrafficViolations trafficViolations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trafficViolations.Id)
            {
                return BadRequest();
            }

            db.Entry(trafficViolations).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrafficViolationsExists(id))
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

        // POST: api/TrafficViolations
        [ResponseType(typeof(TrafficViolations))]
        public async Task<IHttpActionResult> PostTrafficViolations(TrafficViolations trafficViolations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrafficFineModels.Add(trafficViolations);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trafficViolations.Id }, trafficViolations);
        }

        // DELETE: api/TrafficViolations/5
        [ResponseType(typeof(TrafficViolations))]
        public async Task<IHttpActionResult> DeleteTrafficViolations(int id)
        {
            TrafficViolations trafficViolations = await db.TrafficFineModels.FindAsync(id);
            if (trafficViolations == null)
            {
                return NotFound();
            }

            db.TrafficFineModels.Remove(trafficViolations);
            await db.SaveChangesAsync();

            return Ok(trafficViolations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrafficViolationsExists(int id)
        {
            return db.TrafficFineModels.Count(e => e.Id == id) > 0;
        }
    }
}