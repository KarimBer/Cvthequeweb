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
    public class Centres_InteretController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Centres_Interet
        public ActionResult Index()
        {
            return View(db.centres_interet.ToList());
        }

        // GET: Centres_Interet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centres_Interet centres_Interet = db.centres_interet.Find(id);
            if (centres_Interet == null)
            {
                return HttpNotFound();
            }
            return View(centres_Interet);
        }

        // GET: Centres_Interet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centres_Interet/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Interet,CandidatId")] Centres_Interet centres_Interet)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                centres_Interet.CandidatId = id.ToString();
                db.centres_interet.Add(centres_Interet);
                db.SaveChanges();
                return RedirectToAction("Create","References");
            }

            return View(centres_Interet);
        }

        // GET: Centres_Interet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centres_Interet centres_Interet = db.centres_interet.Find(id);
            if (centres_Interet == null)
            {
                return HttpNotFound();
            }
            return View(centres_Interet);
        }

        // POST: Centres_Interet/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Interet,CandidatId")] Centres_Interet centres_Interet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centres_Interet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centres_Interet);
        }

        // GET: Centres_Interet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centres_Interet centres_Interet = db.centres_interet.Find(id);
            if (centres_Interet == null)
            {
                return HttpNotFound();
            }
            return View(centres_Interet);
        }

        // POST: Centres_Interet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Centres_Interet centres_Interet = db.centres_interet.Find(id);
            db.centres_interet.Remove(centres_Interet);
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
