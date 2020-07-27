using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PhoneBookWebApp.DAL;
using PhoneBookWebApp.Models;
using System.Data;

namespace PhoneBookWebApp.Controllers
{
    public class SearchController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        // GET: Search
        public ActionResult Index()
        {
            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "Email", Value = "Email" });
            listGroup.Add(new SelectListItem { Text = "Phone", Value = "Phone" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            List<SelectListItem> listorderGroup = new List<SelectListItem>();
            listorderGroup.Add(new SelectListItem { Text = "Ascending", Value = "Ascending" });
            listorderGroup.Add(new SelectListItem { Text = "Descending", Value = "Descending" });
            ViewBag.listDropDown = listGroup;
            ViewBag.order = listorderGroup;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection group)
        {
            if (!String.IsNullOrEmpty(group["selects"]))
            {
                switch (group["selects"])
                {
                    case "Email":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            var start =group["Start"];
                            var nr = group["count"];
                            if(group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Skip(start);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                        break;
                    case "Phone":
                        Console.WriteLine("Today is Sunday.");
                        break;
                    case "State":
                        Console.WriteLine("Today is Sunday.");
                        break;
                    case "Country":
                        Console.WriteLine("Today is Sunday.");
                        break;
                    case "City":
                        Console.WriteLine("Today is Sunday.");
                        break;

                }
            }



                return RedirectToAction("Index");
        }







        // GET: Search
        public ActionResult Search()
        {

            List<People> peoples = db.Peoples.ToList();

            List<SelectListItem> listGroup = new List<SelectListItem>();
            listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
            listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
            listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
            listGroup.Add(new SelectListItem { Text = "Pin Code", Value = "Pin Code" });

            ViewBag.listDropDown = listGroup;
            ViewBag.Count = 0;
            return View(peoples);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection groupByString)
        {

         
            if (!String.IsNullOrEmpty(groupByString["select"]))
            {


                List<SelectListItem> listGroup = new List<SelectListItem>();

                listGroup.Add(new SelectListItem { Text = "City", Value = "City" });
                listGroup.Add(new SelectListItem { Text = "State", Value = "State" });
                listGroup.Add(new SelectListItem { Text = "Country", Value = "Country" });
                listGroup.Add(new SelectListItem { Text = "Pin Code", Value = "Pin Code" });

                ViewBag.listDropDown = listGroup;
                List<People> people = db.Peoples.Where(p => p.IsActive).ToList();




                var peopleGroup = db.Peoples.GroupBy(p => p.CityId).OrderBy( p => p.Key);

                foreach (var g in peopleGroup)
                {
                    var cid = g.Key;
                    foreach (var s in g)
                    {
                        List<People> speople = people.Where(p => p.CityId.Equals(cid)).ToList();
                        people.Concat(speople);
                    }


                }
                ViewBag.Count = people.Count();
                return View(people);
            }
    

            return RedirectToAction("Search");
        }



    }
}
