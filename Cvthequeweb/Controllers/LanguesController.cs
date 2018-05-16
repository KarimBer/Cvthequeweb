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
    public class LanguesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Langues
        public ActionResult Index()
        {
            return View(db.langues.ToList());
        }

        // GET: Langues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langues langues = db.langues.Find(id);
            if (langues == null)
            {
                return HttpNotFound();
            }
            return View(langues);
        }

        // GET: Langues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Langues/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Langue,Niveau,CandidatId")] Langues langues)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                langues.CandidatId = id.ToString();
                db.langues.Add(langues);
                db.SaveChanges();
                return RedirectToAction("Create","Centres_Interet");
            }

            return View(langues);
        }

        // GET: Langues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langues langues = db.langues.Find(id);
            if (langues == null)
            {
                return HttpNotFound();
            }
            return View(langues);
        }

        // POST: Langues/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Langue,Niveau,CandidatId")] Langues langues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(langues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(langues);
        }

        // GET: Langues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langues langues = db.langues.Find(id);
            if (langues == null)
            {
                return HttpNotFound();
            }
            return View(langues);
        }

        // POST: Langues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Langues langues = db.langues.Find(id);
            db.langues.Remove(langues);
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
