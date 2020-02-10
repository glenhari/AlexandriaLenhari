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
    public class LivroAutorsController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: LivroAutors
        public ActionResult Index()
        {
            var livroAutor = db.LivroAutor.Include(l => l.Autor).Include(l => l.Livro);
            return View(livroAutor.ToList());
        }

        // GET: LivroAutors/Details/5
        public ActionResult Details(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivroAutor livroAutor = db.LivroAutor.Find(id, id2);
            if (livroAutor == null)
            {
                return HttpNotFound();
            }
            return View(livroAutor);
        }

        // GET: LivroAutors/Create
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "AutorNome");
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo");
            return View();
        }

        // POST: LivroAutors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,AutorId")] LivroAutor livroAutor)
        {
            if (ModelState.IsValid)
            {
                db.LivroAutor.Add(livroAutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "AutorNome", livroAutor.AutorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // GET: LivroAutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivroAutor livroAutor = db.LivroAutor.Find(id);
            if (livroAutor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "AutorNome", livroAutor.AutorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // POST: LivroAutors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,AutorId")] LivroAutor livroAutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livroAutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "AutorNome", livroAutor.AutorId);
            ViewBag.LivroId = new SelectList(db.Livro, "LivroId", "LivroTitulo", livroAutor.LivroId);
            return View(livroAutor);
        }

        // GET: LivroAutors/Delete/5
        public ActionResult Delete(int? id, int id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivroAutor livroAutor = db.LivroAutor.Find(id, id2);
            if (livroAutor == null)
            {
                return HttpNotFound();
            }
            return View(livroAutor);
        }

        // POST: LivroAutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            LivroAutor livroAutor = db.LivroAutor.Find(id, id2);
            db.LivroAutor.Remove(livroAutor);
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
