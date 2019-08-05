using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db;
        
        public SuperheroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Superhero
        public ActionResult Index()
        {
            return View(db.Heroes.ToList());
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            Superhero superhero = db.Heroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Heroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                }
                Superhero superhero = db.Heroes.Find(id);
                if (superhero == null)
                {
                    return HttpNotFound();
                }
                return View(superhero);
            }
            catch
            {
                return View();
            }
            
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superhero).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
            //try
            //{
            //    // TODO: Add update logic here
            //    var hero =
            //        (from h in db.Heroes
            //         where h.Id == superhero.Id
            //         select h).FirstOrDefault();
            //    hero.HeroName = ""; //needs to read input from html ?no?
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            Superhero superhero = db.Heroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                Superhero superhero1 =
                    (from h in db.Heroes
                     where h.Id == superhero.Id
                     select h).First();
                db.Heroes.Remove(superhero1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
