namespace Andinoart_app.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using API.Models;
    using Common.Models;
    using Domain.Models;


    public class ArtisansController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Artisans
        public async Task<IHttpActionResult> GetArtisans()
        {
            var responses = new List<ArtisanResponse>();
            var artisans = await db.Artisans.ToListAsync();

             responses.AddRange(artisans.Select(a => new ArtisanResponse
            {
                DNI = a.DNI,
                FirstName = a.FirstName,
                LastName = a.LastName,
                SecondLastName = a.SecondLastName,
                ArtesanalLine = a.ArtesanalLine,
                Email = a.Email,
                Cellphone = a.Cellphone,
                Address = a.Address,
                History = a.History,
                IsActive = a.IsActive,
                CreatedOn = a.CreatedOn,
                ArtisanId=a.ArtisanId,
                Products=a.Products,
            }));
            return Ok(responses);
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
            artisan.IsActive = true;
            artisan.CreatedOn = DateTime.Now.ToUniversalTime();

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