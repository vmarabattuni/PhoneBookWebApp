using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookWebApp.DAL;
using PhoneBookWebApp.Models;

namespace PhoneBookWebApp.Controllers
{
    public class CitiesController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.State);
            cities = cities.Where(c => c.IsActive.Equals(true));
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null || city.IsActive.Equals(false))
            {
                ViewBag.Error = "City  is not found";
                return View("Error");
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            List<State> states = db.States.Where(s => s.IsActive).ToList();
            ViewBag.StateId = new SelectList(states, "SateId", "StateName");
            if (ViewBag.StateId != null)
            {
                return View();
            }
            else
            {
                ViewBag.Error = "Country is required before adding state";
                return View();
            }

        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,IsActive,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
               
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null || city.IsActive.Equals(false))
            {
                ViewBag.Error = "City is not found";
                return View("Error");
            }
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", city.StateId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,IsActive,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "SateId", "StateName", city.StateId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null || city.IsActive.Equals(false))
            {
                ViewBag.Error = "City is not found";
                return View("Error");
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<People> people = db.Peoples.Where(p => p.CityId == id && p.IsActive).ToList();

            if (people.Count > 0)
            {
                ViewBag.Error = "Can not delete Because there exists people in this City";
                return View("Error");
            }
            else
            {
                City city = db.Cities.Find(id);
                db.Cities.Remove(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
