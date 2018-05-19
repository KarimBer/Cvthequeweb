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
    public class CertificationsController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Certifications
        public ActionResult Index()
        {
            var certifications = db.Certifications.Include(c => c.Candidat);
            return View(certifications.ToList());
        }

        // GET: Certifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // GET: Certifications/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Certifications/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom_Certification,Nom_Organisme,Date_Obtention,Id_Candiat")] Certification certification)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                certification.Id_Candiat = int.Parse(id.ToString());
                db.Certifications.Add(certification);
                db.SaveChanges();
                return RedirectToAction("Create","Competences_Professionnelles");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", certification.Id_Candiat);
            return View(certification);
        }

        // GET: Certifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", certification.Id_Candiat);
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom_Certification,Nom_Organisme,Date_Obtention,Id_Candiat")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", certification.Id_Candiat);
            return View(certification);
        }

        // GET: Certifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certification certification = db.Certifications.Find(id);
            db.Certifications.Remove(certification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus(Certification certification,
            string nom_certif,string nom_organisme,DateTime date_obtention)
        {
            var id = Session["IdCandidat"];
            certification.Nom_Certification = nom_certif;
            certification.Nom_Organisme = nom_organisme;
            certification.Date_Obtention = date_obtention.ToString();
            certification.Id_Candiat = int.Parse(id.ToString());
            db.Certifications.Add(certification);
            db.SaveChanges();
            return Json(0);
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
