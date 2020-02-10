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
    public class EmprestimoesController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Emprestimoes
        public ActionResult Index()
        {
            var emprestimo = db.Emprestimo.Include(e => e.Exemplar).Include(e => e.Usuario);
            return View(emprestimo.ToList());
        }

        // GET: Emprestimoes/Details/5
        public ActionResult Details(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id, id2);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public ActionResult Create()
        {
            ViewBag.ExemplarId = new SelectList(db.Exemplar, "ExemplarId", "ExemplarSerial");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Emprestimoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,ExemplarId,EmprestimoData,EmprestimoEntrega")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimo.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExemplarId = new SelectList(db.Exemplar, "ExemplarId", "ExemplarSerial", emprestimo.ExemplarId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "UsuarioNome", emprestimo.UsuarioId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public ActionResult Edit(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id, id2);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExemplarId = new SelectList(db.Exemplar, "ExemplarId", "ExemplarSerial", emprestimo.ExemplarId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "UsuarioNome", emprestimo.UsuarioId);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,ExemplarId,EmprestimoData,EmprestimoEntrega")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExemplarId = new SelectList(db.Exemplar, "ExemplarId", "ExemplarSerial", emprestimo.ExemplarId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "UsuarioId", "UsuarioNome", emprestimo.UsuarioId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public ActionResult Delete(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id, id2);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Emprestimo emprestimo = db.Emprestimo.Find(id, id2);
            db.Emprestimo.Remove(emprestimo);
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
