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
    public class Poste_SouhaiteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Poste_Souhaite
        public ActionResult Index()
        {
            return View(db.poste_souhaite.ToList());
        }

        // GET: Poste_Souhaite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.poste_souhaite.Find(id);
            if (poste_Souhaite == null)
            {
                return HttpNotFound();
            }
            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poste_Souhaite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre_Poste,Fourchette_salariale,Secteur_Activite,Mobile,CandidatId")] Poste_Souhaite poste_Souhaite)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                poste_Souhaite.CandidatId = id.ToString();
                db.poste_souhaite.Add(poste_Souhaite);
                db.SaveChanges();
                return RedirectToAction("Index","Candidat");
            }

            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.poste_souhaite.Find(id);
            if (poste_Souhaite == null)
            {
                return HttpNotFound();
            }
            return View(poste_Souhaite);
        }

        // POST: Poste_Souhaite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre_Poste,Fourchette_salariale,Secteur_Activite,Mobile,CandidatId")] Poste_Souhaite poste_Souhaite)
        {      
            if (ModelState.IsValid)
            {
                db.Entry(poste_Souhaite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.poste_souhaite.Find(id);
            if (poste_Souhaite == null)
            {
                return HttpNotFound();
            }
            return View(poste_Souhaite);
        }

        // POST: Poste_Souhaite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poste_Souhaite poste_Souhaite = db.poste_souhaite.Find(id);
            db.poste_souhaite.Remove(poste_Souhaite);
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
