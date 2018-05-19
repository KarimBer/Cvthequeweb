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
    public class ReferencesController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: References
        public ActionResult Index()
        {
            var references = db.References.Include(r => r.Candidat);
            return View(references.ToList());
        }

        // GET: References/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // GET: References/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: References/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Titre,Entreprise,Telephone,Email,typee,Id_Candiat")] Reference reference)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                reference.Id_Candiat = int.Parse(id.ToString());
                db.References.Add(reference);
                db.SaveChanges();
                return RedirectToAction("Create","Poste_Souhaite");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", reference.Id_Candiat);
            return View(reference);
        }

        // GET: References/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", reference.Id_Candiat);
            return View(reference);
        }

        // POST: References/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Titre,Entreprise,Telephone,Email,typee,Id_Candiat")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", reference.Id_Candiat);
            return View(reference);
        }

        // GET: References/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reference reference = db.References.Find(id);
            db.References.Remove(reference);
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
