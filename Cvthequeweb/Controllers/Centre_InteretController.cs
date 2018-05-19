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
    public class Centre_InteretController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Centre_Interet
        public ActionResult Index()
        {
            var centre_Interet = db.Centre_Interet.Include(c => c.Candidat);
            return View(centre_Interet.ToList());
        }

        // GET: Centre_Interet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centre_Interet centre_Interet = db.Centre_Interet.Find(id);
            if (centre_Interet == null)
            {
                return HttpNotFound();
            }
            return View(centre_Interet);
        }

        // GET: Centre_Interet/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Centre_Interet/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Interet,Id_Candiat")] Centre_Interet centre_Interet)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                centre_Interet.Id_Candiat = int.Parse(id.ToString());
                db.Centre_Interet.Add(centre_Interet);
                db.SaveChanges();
                return RedirectToAction("Create","References");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", centre_Interet.Id_Candiat);
            return View(centre_Interet);
        }

        // GET: Centre_Interet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centre_Interet centre_Interet = db.Centre_Interet.Find(id);
            if (centre_Interet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", centre_Interet.Id_Candiat);
            return View(centre_Interet);
        }

        // POST: Centre_Interet/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Interet,Id_Candiat")] Centre_Interet centre_Interet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centre_Interet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", centre_Interet.Id_Candiat);
            return View(centre_Interet);
        }

        // GET: Centre_Interet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Centre_Interet centre_Interet = db.Centre_Interet.Find(id);
            if (centre_Interet == null)
            {
                return HttpNotFound();
            }
            return View(centre_Interet);
        }

        // POST: Centre_Interet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Centre_Interet centre_Interet = db.Centre_Interet.Find(id);
            db.Centre_Interet.Remove(centre_Interet);
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
