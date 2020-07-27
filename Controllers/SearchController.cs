﻿using Microsoft.Ajax.Utilities;
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
using System.Collections;

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
            ViewBag.Counts = 0;
            ViewBag.order = listorderGroup;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection group)
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
            ViewBag.Counts = 0;
            ViewBag.order = listorderGroup;
            if (!String.IsNullOrEmpty(group["selects"]))
            {
                ViewBag.SelectedField = group["selects"];
                
                var start = group["Start"];
                var nr = group["count"];
                switch (group["selects"])
                {
                    
                    case "Email":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            
                            if(group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderBy(p => p.Email).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderByDescending(p => p.Email).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                    case "Phone":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderBy(p => p.PhoneNumber).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderByDescending(p => p.PhoneNumber).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "State":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                            
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderBy(p => p.StateId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderByDescending(p => p.StateId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                       
                    case "Country":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                           
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderBy(p => p.CountryId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Lists = li;
                                ViewBag.Counts = li.Count();
                                return View();
                            }
                            else
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderByDescending(p => p.CountryId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }
                    case "City":
                        if (!String.IsNullOrEmpty(group["Start"]))
                        {
                           
                            if (group["order"] == "Ascending")
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderBy(p => p.CityId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                            else
                            {
                                var li = db.Peoples.Where(p => p.IsActive).OrderByDescending(p => p.CityId).Skip(int.Parse(start) - 1).Take(int.Parse(nr)).ToList();
                                ViewBag.Counts = li.Count();
                                ViewBag.Lists = li;
                                return View();
                            }
                        }
                        else
                        {
                            break;
                        }

                }
                return RedirectToAction("Index");
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


                switch (groupByString["select"])
                {
                    case "City":
                        var peoplecGroup = db.Peoples.GroupBy(p => p.CityId).OrderBy(p => p.Key);

                        foreach (var g in peoplecGroup)
                        {
                            var cid = g.Key;
                            foreach (var s in g)
                            {
                                List<People> speople = people.Where(p => p.CityId.Equals(cid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                        

                    case "State":
                        var peoplesGroup = db.Peoples.GroupBy(p => p.StateId).OrderBy(p => p.Key);

                        foreach (var g in peoplesGroup)
                        {
                            var sid = g.Key;
                            foreach (var s in g)
                            {
                                List<People> speople = people.Where(p => p.StateId.Equals(sid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                    case "Country":
                        var peopleCGroup = db.Peoples.GroupBy(p => p.CountryId).OrderBy(p => p.Key);

                        foreach (var g in peopleCGroup)
                        {
                            var Cid = g.Key;
                            foreach (var s in g)
                            {
                                List<People> speople = people.Where(p => p.CountryId.Equals(Cid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                    case "Pin Code":
                        var peoplepGroup = db.Peoples.GroupBy(p => p.PinCode).OrderBy(p => p.Key);

                        foreach (var g in peoplepGroup)
                        {
                            var pid = g.Key;
                            foreach (var s in g)
                            {
                                List<People> speople = people.Where(p => p.CountryId.Equals(pid)).ToList();
                                people.Concat(speople);
                            }


                        }
                        ViewBag.Count = people.Count();
                        break;
                }
                return View(people);
            }
    

            return RedirectToAction("Search");
        }



    }
}
