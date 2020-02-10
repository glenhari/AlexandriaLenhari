using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alexandria.Models;

namespace Alexandria.Controllers
{
    public class ExemplarsController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Exemplars
        public ActionResult Index()
        {
            var exemplar = db.Exemplar.Include(e => e.Livro);
            return View(exemplar.ToList());
        }

        // GET: Exemplars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplar exemplar = db.Exemplar.Find(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            return View(exemplar);
        }

        // GET: Exemplars/Create
        public ActionResult Create()
        {
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo");
            return View();
        }

        // POST: Exemplars/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExemplarId,LivroId,ExemplarSerial")] Exemplar exemplar)
        {
            if (ModelState.IsValid)
            {
                db.Exemplar.Add(exemplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", exemplar.LivroId);
            return View(exemplar);
        }

        // GET: Exemplars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplar exemplar = db.Exemplar.Find(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", exemplar.LivroId);
            return View(exemplar);
        }

        // POST: Exemplars/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExemplarId,LivroId,ExemplarSerial")] Exemplar exemplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exemplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", exemplar.LivroId);
            return View(exemplar);
        }

        // GET: Exemplars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exemplar exemplar = db.Exemplar.Find(id);
            if (exemplar == null)
            {
                return HttpNotFound();
            }
            return View(exemplar);
        }

        // POST: Exemplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exemplar exemplar = db.Exemplar.Find(id);
            db.Exemplar.Remove(exemplar);
            db.SaveChanges();
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
