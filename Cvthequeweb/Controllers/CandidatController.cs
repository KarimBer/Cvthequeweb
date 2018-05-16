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
        // GET: Candidat
        public ActionResult Index()
        {
            var db = new Models.ApplicationDbContext();
            List<Candidat> news = db.candidat.ToList();
            return View(news);
        }
        public ActionResult Add()
        {
            var viewmodel = new Candidatviewmodel()
            {
                candidat = new Candidat()
            };
            return View("Add", viewmodel);
        }
        [HttpPost]
        public ActionResult Save(Candidat candidat)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new Candidatviewmodel()
                {
                    candidat = candidat
                };
                return View("Add", viewmodel);
            }
            var db = new ApplicationDbContext();
            if (candidat.Id == 0)
            {
                db.candidat.Add(candidat);
            }
            else
            {
                var candidatdb = db.candidat.SingleOrDefault(u => u.Id == candidat.Id);
                if (candidatdb == null)
                {
                    return HttpNotFound();
                }
                if (db.candidat.SingleOrDefault(u => u.Id != candidat.Id) != null)
                {
                    var viewmodel = new Candidatviewmodel()
                    {
                        candidat = new Candidat(),
                    };
                    return View("Add", viewmodel);
                }
                candidatdb.Nom = candidat.Nom;
                candidatdb.Prenom= candidat.Prenom;
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
            Session["IdCandidat"] = candidat.Id;
            return RedirectToAction("Create","Experiences_Pro");
        }
        public ActionResult update(int Id)
        {
            var db = new ApplicationDbContext();
            var candidat = db.candidat.SingleOrDefault(n => n.Id == Id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new Candidatviewmodel()
            {
                candidat = candidat
            };
            return View("Add",viewmodel);
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

        //public ActionResult Plus(Candidat candidat)
        //{
        //    var db = new ApplicationDbContext();
        //    candidat.Nom = "aa";
        //    candidat.Prenom = "aaaa";
        //    candidat.Email = "a@a.a";
        //    candidat.Tel = "0607486054";
        //    candidat.Adresse = "aaa";
        //    candidat.Date_Naissance = DateTime.Today;
        //    candidat.Genre = "aaa";
        //    candidat.Situation_Familiale = "aaa";
        //    candidat.Ville = "aaaaa";
        //    candidat.CIN = "aaa";
        //    db.candidat.Add(candidat);
        //    db.SaveChanges();
        //    return Json(0);
        //}
    }
}