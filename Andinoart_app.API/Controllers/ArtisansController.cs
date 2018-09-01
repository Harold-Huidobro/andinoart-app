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
using Andinoart_app.Common.Models;
using Andinoart_app.Domain.Models;

namespace Andinoart_app.API.Controllers
{
    public class ArtisansController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Artisans
        public IQueryable<Artisan> GetArtisans()
        {
            return db.Artisans;
        }

        // GET: api/Artisans/5
        [ResponseType(typeof(Artisan))]
        public async Task<IHttpActionResult> GetArtisan(int id)
        {
            Artisan artisan = await db.Artisans.FindAsync(id);
            if (artisan == null)
            {
                return NotFound();
            }

            return Ok(artisan);
        }

        // PUT: api/Artisans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtisan(int id, Artisan artisan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artisan.ArtisanId)
            {
                return BadRequest();
            }

            db.Entry(artisan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtisanExists(id))
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

        // POST: api/Artisans
        [ResponseType(typeof(Artisan))]
        public async Task<IHttpActionResult> PostArtisan(Artisan artisan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artisans.Add(artisan);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = artisan.ArtisanId }, artisan);
        }

        // DELETE: api/Artisans/5
        [ResponseType(typeof(Artisan))]
        public async Task<IHttpActionResult> DeleteArtisan(int id)
        {
            Artisan artisan = await db.Artisans.FindAsync(id);
            if (artisan == null)
            {
                return NotFound();
            }

            db.Artisans.Remove(artisan);
            await db.SaveChangesAsync();

            return Ok(artisan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtisanExists(int id)
        {
            return db.Artisans.Count(e => e.ArtisanId == id) > 0;
        }
    }
}