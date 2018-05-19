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
    public class LanguesController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Langues
        public ActionResult Index()
        {
            var langues = db.Langues.Include(l => l.Candidat);
            return View(langues.ToList());
        }

        // GET: Langues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // GET: Langues/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Langues/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Langue1,Niveau,Id_Candiat")] Langue langue)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                langue.Id_Candiat = int.Parse(id.ToString());
                db.Langues.Add(langue);
                db.SaveChanges();
                return RedirectToAction("Create","Centre_Interet");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", langue.Id_Candiat);
            return View(langue);
        }

        // GET: Langues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", langue.Id_Candiat);
            return View(langue);
        }

        // POST: Langues/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Langue1,Niveau,Id_Candiat")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(langue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", langue.Id_Candiat);
            return View(langue);
        }

        // GET: Langues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Langue langue = db.Langues.Find(id);
            if (langue == null)
            {
                return HttpNotFound();
            }
            return View(langue);
        }

        // POST: Langues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Langue langue = db.Langues.Find(id);
            db.Langues.Remove(langue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus(Langue langue,string Languee,string niveau)
        {
            var id = Session["IdCandidat"];
            langue.Langue1 = Languee;
            langue.Niveau = niveau;
            langue.Id_Candiat = int.Parse(id.ToString());
            db.Langues.Add(langue);
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
