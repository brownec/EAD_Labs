// Cliff Browne - X00014810
// EAD CA2 - 25 November 2014

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            // ID being passed in - setting value PK of 1
            id = 1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Car car = db.Cars.Find(id);
            // create a new car object
            Car car = new Car();
            car.Make = "Alfa Romeo";
            car.Model = "156";
            // sets the variable (carenginetype) to the enum type
            car.CarEngineType = CarEngineType.Petrol;
            car.EngineSize = 1600;

            // TASK 1
            /* The controller should work out what the current date and time are and pass 
				them into the view as property of ViewBag. 
             * Use the existing default controller HomeController to achieve this. 
             * The view itself should work out the time zone and display that in addition 
				to the date and time. 
             * Hint: use DateTime.Now and TimeZone.CurrentTimeZone.StandardName. 
             * Change the styling, use a red for html heading elements. 
             */
            TimeZone tz = TimeZone.CurrentTimeZone;
            String zone = tz.StandardName.ToString();
            String time = DateTime.Now.ToString();

            ViewBag.Task1 = new String[] { zone, time };

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Make,Model,EngineSize,CarEngineType")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Make,Model,EngineSize,CarEngineType")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
