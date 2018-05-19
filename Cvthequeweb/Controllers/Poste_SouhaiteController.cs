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
    public class Poste_SouhaiteController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Poste_Souhaite
        public ActionResult Index()
        {
            var poste_Souhaite = db.Poste_Souhaite.Include(p => p.Candidat);
            return View(poste_Souhaite.ToList());
        }

        // GET: Poste_Souhaite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.Poste_Souhaite.Find(id);
            if (poste_Souhaite == null)
            {
                return HttpNotFound();
            }
            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Poste_Souhaite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre_Poste,Fourchette_Salarial,Secteur_Activite,Mobile,Id_Candiat")] Poste_Souhaite poste_Souhaite)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                poste_Souhaite.Id_Candiat = int.Parse(id.ToString());
                db.Poste_Souhaite.Add(poste_Souhaite);
                db.SaveChanges();
                return RedirectToAction("Index","Candidats");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", poste_Souhaite.Id_Candiat);
            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.Poste_Souhaite.Find(id);
            if (poste_Souhaite == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", poste_Souhaite.Id_Candiat);
            return View(poste_Souhaite);
        }

        // POST: Poste_Souhaite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre_Poste,Fourchette_Salarial,Secteur_Activite,Mobile,Id_Candiat")] Poste_Souhaite poste_Souhaite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poste_Souhaite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", poste_Souhaite.Id_Candiat);
            return View(poste_Souhaite);
        }

        // GET: Poste_Souhaite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poste_Souhaite poste_Souhaite = db.Poste_Souhaite.Find(id);
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
            Poste_Souhaite poste_Souhaite = db.Poste_Souhaite.Find(id);
            db.Poste_Souhaite.Remove(poste_Souhaite);
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
