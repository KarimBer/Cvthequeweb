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
    public class Competences_ProController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Competences_Pro
        public ActionResult Index()
        {
            return View(db.competences_pro.ToList());
        }

        // GET: Competences_Pro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Pro competences_Pro = db.competences_pro.Find(id);
            if (competences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(competences_Pro);
        }

        // GET: Competences_Pro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competences_Pro/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Competences,CandidatId")] Competences_Pro competences_Pro)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                competences_Pro.CandidatId = id.ToString();
                db.competences_pro.Add(competences_Pro);
                db.SaveChanges();
                return RedirectToAction("Create","Projet_Realise");
            }

            return View(competences_Pro);
        }

        // GET: Competences_Pro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Pro competences_Pro = db.competences_pro.Find(id);
            if (competences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(competences_Pro);
        }

        // POST: Competences_Pro/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Competences,CandidatId")] Competences_Pro competences_Pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competences_Pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competences_Pro);
        }

        // GET: Competences_Pro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences_Pro competences_Pro = db.competences_pro.Find(id);
            if (competences_Pro == null)
            {
                return HttpNotFound();
            }
            return View(competences_Pro);
        }

        // POST: Competences_Pro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competences_Pro competences_Pro = db.competences_pro.Find(id);
            db.competences_pro.Remove(competences_Pro);
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
