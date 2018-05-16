using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cvthequeweb.Models;

namespace Cvthequeweb.Controllers
{
    public class ReferencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: References
        public ActionResult Index()
        {
            return View(db.references.ToList());
        }

        // GET: References/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            References references = db.references.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // GET: References/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Titre,Entreprise,Telephone,Email,Type,CandidatId")] References references)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                references.CandidatId = id.ToString();
                db.references.Add(references);
                db.SaveChanges();
                return RedirectToAction("Create","Poste_Souhaite");
            }

            return View(references);
        }

        // GET: References/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            References references = db.references.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // POST: References/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Titre,Entreprise,Telephone,Email,Type,CandidatId")] References references)
        {
            if (ModelState.IsValid)
            {
                db.Entry(references).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(references);
        }

        // GET: References/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            References references = db.references.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            References references = db.references.Find(id);
            db.references.Remove(references);
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
