using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cvthequeweb;

namespace Cvthequeweb.Controllers
{
    public class Competences_ProfessionnellesController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Competences_Professionnelles
        public ActionResult Index()
        {
            var competences_Professionnelles = db.Competences_Professionnelles.Include(c => c.Candidat);
            return View(competences_Professionnelles.ToList());
        }

        // GET: Competences_Professionnelles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Professionnelles competences_Professionnelles = db.Competences_Professionnelles.Find(id);
            if (competences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            return View(competences_Professionnelles);
        }

        // GET: Competences_Professionnelles/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Competences_Professionnelles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Competence,Id_Candiat")] Competences_Professionnelles competences_Professionnelles)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                competences_Professionnelles.Id_Candiat = int.Parse(id.ToString());
                db.Competences_Professionnelles.Add(competences_Professionnelles);
                db.SaveChanges();
                return RedirectToAction("Create","Projet_Realise");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", competences_Professionnelles.Id_Candiat);
            return View(competences_Professionnelles);
        }

        // GET: Competences_Professionnelles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Professionnelles competences_Professionnelles = db.Competences_Professionnelles.Find(id);
            if (competences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", competences_Professionnelles.Id_Candiat);
            return View(competences_Professionnelles);
        }

        // POST: Competences_Professionnelles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Competence,Id_Candiat")] Competences_Professionnelles competences_Professionnelles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competences_Professionnelles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", competences_Professionnelles.Id_Candiat);
            return View(competences_Professionnelles);
        }

        // GET: Competences_Professionnelles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Professionnelles competences_Professionnelles = db.Competences_Professionnelles.Find(id);
            if (competences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            return View(competences_Professionnelles);
        }

        // POST: Competences_Professionnelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competences_Professionnelles competences_Professionnelles = db.Competences_Professionnelles.Find(id);
            db.Competences_Professionnelles.Remove(competences_Professionnelles);
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
