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
    public class Experiences_ProfessionnellesController : Controller
    {
        private CVThequeEntities db = new CVThequeEntities();

        // GET: Experiences_Professionnelles
        public ActionResult Index()
        {
            var experiences_Professionnelles = db.Experiences_Professionnelles.Include(e => e.Candidat);
            return View(experiences_Professionnelles.ToList());
        }

        // GET: Experiences_Professionnelles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Professionnelles experiences_Professionnelles = db.Experiences_Professionnelles.Find(id);
            if (experiences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            return View(experiences_Professionnelles);
        }

        // GET: Experiences_Professionnelles/Create
        public ActionResult Create()
        {
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom");
            return View();
        }

        // POST: Experiences_Professionnelles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date_Debut,Date_Fin,Nature,tyype,Employeur,Secteur_Activité,Titre_Poste,descriptiion,Duree,Id_Candiat")] Experiences_Professionnelles experiences_Professionnelles)
        {
            var id = Session["IdCandidat"];
            if (ModelState.IsValid)
            {
                experiences_Professionnelles.Id_Candiat= int.Parse(id.ToString());
                db.Experiences_Professionnelles.Add(experiences_Professionnelles);
                db.SaveChanges();
                return RedirectToAction("Create","Formations");
            }

            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", experiences_Professionnelles.Id_Candiat);
            return View(experiences_Professionnelles);
        }

        // GET: Experiences_Professionnelles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Professionnelles experiences_Professionnelles = db.Experiences_Professionnelles.Find(id);
            if (experiences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", experiences_Professionnelles.Id_Candiat);
            return View(experiences_Professionnelles);
        }

        // POST: Experiences_Professionnelles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date_Debut,Date_Fin,Nature,tyype,Employeur,Secteur_Activité,Titre_Poste,descriptiion,Duree,Id_Candiat")] Experiences_Professionnelles experiences_Professionnelles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiences_Professionnelles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Candiat = new SelectList(db.Candidats, "Id", "Nom", experiences_Professionnelles.Id_Candiat);
            return View(experiences_Professionnelles);
        }

        // GET: Experiences_Professionnelles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiences_Professionnelles experiences_Professionnelles = db.Experiences_Professionnelles.Find(id);
            if (experiences_Professionnelles == null)
            {
                return HttpNotFound();
            }
            return View(experiences_Professionnelles);
        }

        // POST: Experiences_Professionnelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiences_Professionnelles experiences_Professionnelles = db.Experiences_Professionnelles.Find(id);
            db.Experiences_Professionnelles.Remove(experiences_Professionnelles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Plus(Experiences_Professionnelles experiences_Pro, DateTime Date_Debut, DateTime Date_Fin,
            string Nature, string Type, string Employeur, string Secteur_Activite,
            string Titre_Poste, string Description, int Duree)
        {
            var id = Session["IdCandidat"];
            experiences_Pro.Date_Debut = Date_Debut.ToString();
            experiences_Pro.Date_Fin = Date_Fin.ToString();
            experiences_Pro.Nature = Nature;
            experiences_Pro.tyype = Type;
            experiences_Pro.Employeur = Employeur;
            experiences_Pro.Secteur_Activité = Secteur_Activite;
            experiences_Pro.Titre_Poste = Titre_Poste;
            experiences_Pro.descriptiion = Description;
            experiences_Pro.Duree = Duree;
            experiences_Pro.Id_Candiat = int.Parse(id.ToString());
            db.Experiences_Professionnelles.Add(experiences_Pro);
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
