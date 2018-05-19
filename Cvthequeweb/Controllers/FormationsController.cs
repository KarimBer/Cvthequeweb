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
    public class FormationsController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Formations
        public ActionResult Index()
        {
            var formations = db.Formations.Include(f => f.Candidat);
            return View(formations.ToList());
        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: Formations/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Formations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Diplome,Specialite,Date_Obtention,Etablissement,Niveau,Id_Candiat")] Formation formation)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                formation.Id_Candiat = int.Parse(id.ToString());
                db.Formations.Add(formation);
                db.SaveChanges();
                return RedirectToAction("Create","Certifications");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", formation.Id_Candiat);
            return View(formation);
        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", formation.Id_Candiat);
            return View(formation);
        }

        // POST: Formations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Diplome,Specialite,Date_Obtention,Etablissement,Niveau,Id_Candiat")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", formation.Id_Candiat);
            return View(formation);
        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formation formation = db.Formations.Find(id);
            db.Formations.Remove(formation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus(Formation formation,string diplome,string specialite,
            DateTime date_obtention,string etablissement,string niveau)
        {
            var id = Session["IdCandidat"];
            formation.Diplome = diplome;
            formation.Specialite = specialite;
            formation.Date_Obtention = date_obtention.ToString();
            formation.Etablissement = etablissement;
            formation.Niveau = niveau;
            formation.Id_Candiat = int.Parse(id.ToString());
            db.Formations.Add(formation);
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
