using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Andinoart_app.Backend.Models;
using Andinoart_app.Common.Models;

namespace Andinoart_app.Backend.Controllers
{
    public class ArtisansController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Artisans
        public async Task<ActionResult> Index()
        {
            return View(await db.Artisans.ToListAsync());
        }

        // GET: Artisans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisan artisan = await db.Artisans.FindAsync(id);
            if (artisan == null)
            {
                return HttpNotFound();
            }
            return View(artisan);
        }

        // GET: Artisans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artisans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArtisanId,DNI,FirstName,LastName,SecondLastName,Cellphone,Address,History,IsActive,CreatedOn")] Artisan artisan)
        {
            if (ModelState.IsValid)
            {
                db.Artisans.Add(artisan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artisan);
        }

        // GET: Artisans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisan artisan = await db.Artisans.FindAsync(id);
            if (artisan == null)
            {
                return HttpNotFound();
            }
            return View(artisan);
        }

        // POST: Artisans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArtisanId,DNI,FirstName,LastName,SecondLastName,Cellphone,Address,History,IsActive,CreatedOn")] Artisan artisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artisan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artisan);
        }

        // GET: Artisans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artisan artisan = await db.Artisans.FindAsync(id);
            if (artisan == null)
            {
                return HttpNotFound();
            }
            return View(artisan);
        }

        // POST: Artisans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Artisan artisan = await db.Artisans.FindAsync(id);
            db.Artisans.Remove(artisan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
