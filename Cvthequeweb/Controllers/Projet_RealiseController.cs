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
    public class Projet_RealiseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projet_Realise
        public ActionResult Index()
        {
            return View(db.projets_realise.ToList());
        }

        // GET: Projet_Realise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.projets_realise.Find(id);
            if (projet_Realise == null)
            {
                return HttpNotFound();
            }
            return View(projet_Realise);
        }

        // GET: Projet_Realise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projet_Realise/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Theme,Organisme,CandidatId")] Projet_Realise projet_Realise)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                projet_Realise.CandidatId = id.ToString();
                db.projets_realise.Add(projet_Realise);
                db.SaveChanges();
                return RedirectToAction("Create","Langues");
            }

            return View(projet_Realise);
        }

        // GET: Projet_Realise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.projets_realise.Find(id);
            if (projet_Realise == null)
            {
                return HttpNotFound();
            }
            return View(projet_Realise);
        }

        // POST: Projet_Realise/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Theme,Organisme,CandidatId")] Projet_Realise projet_Realise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet_Realise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projet_Realise);
        }

        // GET: Projet_Realise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.projets_realise.Find(id);
            if (projet_Realise == null)
            {
                return HttpNotFound();
            }
            return View(projet_Realise);
        }

        // POST: Projet_Realise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet_Realise projet_Realise = db.projets_realise.Find(id);
            db.projets_realise.Remove(projet_Realise);
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
