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
    public class Experiences_ProController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experiences_Pro
        public ActionResult Index()
        {
            return View(db.experiences_pro.ToList());
        }

        // GET: Experiences_Pro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Pro experiences_Pro = db.experiences_pro.Find(id);
            if (experiences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(experiences_Pro);
        }

        // GET: Experiences_Pro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiences_Pro/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date_Debut,Date_Fin,Nature,Type,Employeur,Secteur_Activite,Titre_Poste,Description,Duree,CandidatId")] Experiences_Pro experiences_Pro)
        {
            if (ModelState.IsValid)
            {
                db.experiences_pro.Add(experiences_Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiences_Pro);
        }

        // GET: Experiences_Pro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Pro experiences_Pro = db.experiences_pro.Find(id);
            if (experiences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(experiences_Pro);
        }

        // POST: Experiences_Pro/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date_Debut,Date_Fin,Nature,Type,Employeur,Secteur_Activite,Titre_Poste,Description,Duree,CandidatId")] Experiences_Pro experiences_Pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiences_Pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiences_Pro);
        }

        // GET: Experiences_Pro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Pro experiences_Pro = db.experiences_pro.Find(id);
            if (experiences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(experiences_Pro);
        }

        // POST: Experiences_Pro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiences_Pro experiences_Pro = db.experiences_pro.Find(id);
            db.experiences_pro.Remove(experiences_Pro);
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
