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
    public class FormationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Formations
        public ActionResult Index()
        {
            return View(db.formations.ToList());
        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formations formations = db.formations.Find(id);
            if (formations == null)
            {
                return HttpNotFound();
            }
            return View(formations);
        }

        // GET: Formations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Diplome,Specialite,Date_Obtention,Etablissement,Niveau,Id_Candidat")] Formations formations)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                formations.CandidatId = id.ToString();
                db.formations.Add(formations);
                db.SaveChanges();
                return RedirectToAction("Create", "Certifications");
            }

            return View(formations);
        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formations formations = db.formations.Find(id);
            if (formations == null)
            {
                return HttpNotFound();
            }
            return View(formations);
        }

        // POST: Formations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Diplome,Specialite,Date_Obtention,Etablissement,Niveau,Id_Candidat")] Formations formations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formations);
        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formations formations = db.formations.Find(id);
            if (formations == null)
            {
                return HttpNotFound();
            }
            return View(formations);
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formations formations = db.formations.Find(id);
            db.formations.Remove(formations);
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
