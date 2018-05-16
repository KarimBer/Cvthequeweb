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
    public class CertificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Certifications
        public ActionResult Index()
        {
            return View(db.certifications.ToList());
        }

        // GET: Certifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            return View(certifications);
        }

        // GET: Certifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certifications/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom_certif,Nom_Organisme,Date_Obtention,CandidatId")] Certifications certifications)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                certifications.CandidatId = id.ToString();
                db.certifications.Add(certifications);
                db.SaveChanges();
                return RedirectToAction("Create","Competences_Pro");
            }

            return View(certifications);
        }

        // GET: Certifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            return View(certifications);
        }

        // POST: Certifications/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom_certif,Nom_Organisme,Date_Obtention,CandidatId")] Certifications certifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certifications);
        }

        // GET: Certifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            return View(certifications);
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certifications certifications = db.certifications.Find(id);
            db.certifications.Remove(certifications);
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
