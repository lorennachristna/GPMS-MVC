using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sustent.Models;

namespace Sustent.Controllers
{
    public class BichoesController : Controller
    {
        private dbSustentEntities db = new dbSustentEntities();

        // GET: Bichoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Bichoes.ToListAsync());
        }

        // GET: Bichoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = await db.Bichoes.FindAsync(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // GET: Bichoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bichoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,especie,kit,descricao")] Bicho bicho)
        {
            if (ModelState.IsValid)
            {
                db.Bichoes.Add(bicho);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bicho);
        }

        // GET: Bichoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = await db.Bichoes.FindAsync(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // POST: Bichoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,especie,kit,descricao")] Bicho bicho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicho).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bicho);
        }

        // GET: Bichoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicho bicho = await db.Bichoes.FindAsync(id);
            if (bicho == null)
            {
                return HttpNotFound();
            }
            return View(bicho);
        }

        // POST: Bichoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bicho bicho = await db.Bichoes.FindAsync(id);
            db.Bichoes.Remove(bicho);
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
