﻿using Superheroes.Models;
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
        public ActionResult Details(int id)
        {
            return View();
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
                return View();
            }
            catch
            {
                return View();
            }
            
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
