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
    public class Projet_RealiseController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Projet_Realise
        public ActionResult Index()
        {
            var projet_Realise = db.Projet_Realise.Include(p => p.Candidat);
            return View(projet_Realise.ToList());
        }

        // GET: Projet_Realise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.Projet_Realise.Find(id);
            if (projet_Realise == null)
            {
                return HttpNotFound();
            }
            return View(projet_Realise);
        }

        // GET: Projet_Realise/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Projet_Realise/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date_Projet,Theme,Organisme,Id_Candiat")] Projet_Realise projet_Realise)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                projet_Realise.Id_Candiat = int.Parse(id.ToString());
                db.Projet_Realise.Add(projet_Realise);
                db.SaveChanges();
                return RedirectToAction("Create","Langues");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", projet_Realise.Id_Candiat);
            return View(projet_Realise);
        }

        // GET: Projet_Realise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.Projet_Realise.Find(id);
            if (projet_Realise == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", projet_Realise.Id_Candiat);
            return View(projet_Realise);
        }

        // POST: Projet_Realise/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date_Projet,Theme,Organisme,Id_Candiat")] Projet_Realise projet_Realise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet_Realise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", projet_Realise.Id_Candiat);
            return View(projet_Realise);
        }

        // GET: Projet_Realise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet_Realise projet_Realise = db.Projet_Realise.Find(id);
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
            Projet_Realise projet_Realise = db.Projet_Realise.Find(id);
            db.Projet_Realise.Remove(projet_Realise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus(Projet_Realise projet_Realise,DateTime date,
            string theme,string organisme)
        {
            var id = Session["IdCandidat"];
            projet_Realise.Date_Projet = date.ToString();
            projet_Realise.Theme = theme;
            projet_Realise.Organisme = organisme;
            projet_Realise.Id_Candiat = int.Parse(id.ToString());
            db.Projet_Realise.Add(projet_Realise);
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
