using Cvthequeweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cvthequeweb.Controllers
{
    public class CandidatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Candidat
        public ActionResult Index()
        {
            var db = new Models.ApplicationDbContext();
            List<Candidat> candidat = db.candidat.ToList();
            return View(candidat);
        }

        public ActionResult Add()
        {
            var vm = new viewmodel()
            {
                candidat= new Candidat(),
                Centres_Interets=db.centres_interet.ToList(),
                certificatiions=db.certifications.ToList(),
                Competences_Pros=db.competences_pro.ToList(),
                Experiences_Pros=db.experiences_pro.ToList(),
                Formatiions=db.formations.ToList(),
                Languees=db.langues.ToList(),
                Postes_Souhaites=db.poste_souhaite.ToList(),
                Projets_Realises=db.projets_realise.ToList(),
                Referencees=db.references.ToList()
            };
            return View("Add", vm);
        }

        [HttpPost]
        public ActionResult Save(Candidat candidat,Centres_Interet centres_Interet,Certifications certifications, Competences_Pro competences_Pro,Experiences_Pro experiences_Pro,Formations formations,Langues langues,Poste_Souhaite poste_Souhaite,Projet_Realise projet_Realise,References references)
        {
            if(!ModelState.IsValid)
            {
                var vm = new viewmodel()
                {
                    candidat = candidat,
                    centres_Interet = centres_Interet,
                    certifications = certifications,
                    competences_Pro = competences_Pro,
                    experiences_Pro = experiences_Pro,
                    formations = formations,
                    langues = langues,
                    poste_Souhaite = poste_Souhaite,
                    projet_Realise = projet_Realise,
                    references = references
                };
                return View("Add", vm);
            }
            var db = new ApplicationDbContext();
            if(candidat.Id==0)
            {
                db.candidat.Add(candidat);
            }else
            {
                var candidatdb = db.candidat.SingleOrDefault(u => u.Id == candidat.Id);
                if (candidatdb == null)
                {
                    return HttpNotFound();
                }
                if(db.candidat.SingleOrDefault(u=>u.Id!=candidat.Id)!=null)
                {
                    var vm = new viewmodel()
                    {
                        candidat = new Candidat()
                    };
                    return View("Add", vm);
                }
                candidatdb.Nom = candidat.Nom;
                candidatdb.Prenom = candidat.Prenom;
                candidatdb.Email = candidat.Email;
                candidatdb.Tel = candidat.Tel;
                candidatdb.Adresse = candidat.Adresse;
                candidatdb.Date_Naissance = candidat.Date_Naissance;
                candidatdb.Genre = candidat.Genre;
                candidatdb.Situation_Familiale = candidat.Situation_Familiale;
                candidatdb.Ville = candidat.Ville;
                candidatdb.CIN = candidat.CIN;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult update(int Id)
        {
            var db = new ApplicationDbContext();
            var candidat = db.candidat.SingleOrDefault(n => n.Id == Id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            var vm = new viewmodel()
            {
                candidat = candidat
            };
            return View("Add", vm);
        }
        public ActionResult delete(int id)
        {
            var db = new ApplicationDbContext();
            var candidat = db.candidat.SingleOrDefault(n => n.Id == id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            db.candidat.Remove(candidat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}