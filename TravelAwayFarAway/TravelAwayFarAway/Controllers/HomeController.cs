using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using TravelAwayFarAway.DAL;

namespace TravelAwayFarAway.Controllers
{
    public class HomeController : Controller
    {
        private ContextClass db = new ContextClass();
        private InterfaceTripRepo _IR;
        
        public HomeController(InterfaceTripRepo ir) //need to make iterface public
        {
            _IR = ir;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        { 

            return View(_IR.displayTrips());
        }

        public ActionResult addLeg() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addLeg(Leg l)
        {
            if (ModelState.IsValid)
            {
                db.leg.Add(l);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l);
        }


        public ActionResult Details(int id = 0)
        {
            Trip trip = db.trip.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.trip.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Trip trip = db.trip.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Trip trip = db.trip.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.trip.Find(id);
            db.trip.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}