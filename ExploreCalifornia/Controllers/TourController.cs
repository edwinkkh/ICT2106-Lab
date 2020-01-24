using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;
namespace ExploreCalifornia.Controllers
{
    public class TourController : Controller
    {
        static Tour tour1 = new Tour
        {
            Id = 1,
            Name = "Cali Walking Tour"
        };

        static Tour tour2 = new Tour
        {
            Id = 2,
            Name = "Cali Cycling Tour"
        };

        static List<Tour> model = new List<Tour>{tour1, tour2 };

        // GET: Tour
        public ActionResult Index()
        {     
            return View(model);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            var tour = model.Where(t => t.Id == id).FirstOrDefault();
            return View("View", tour);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Random random = new Random();
                int id = random.Next();
                bool includeMeal = false;
                if (collection["IncludesMeals"] == "1"){
                    includeMeal = true;
                }
                Tour tour = new Tour
                {
                    Id = id,
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Length = Convert.ToInt32(collection["Length"]),
                    Price = Convert.ToDecimal(collection["Price"]),
                    Rating = collection["Rating"],
                    IncludesMeals = includeMeal
                };
                model.Add(tour);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Details), new {Id = id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            var tour = model.Where(t => t.Id == id).FirstOrDefault();
            return View(tour);
        }

        // POST: Tour/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var tour = model.Where(t => t.Id == id).FirstOrDefault();
                tour.Name = collection["Name"];
                tour.Description = collection["Description"];
                tour.Length = Convert.ToInt32(collection["Length"]);
                tour.Price = Convert.ToDecimal(collection["Price"]);
                tour.Rating = collection["Rating"];
                bool includeMeal = false;
                if (collection["IncludesMeals"] == 1)
                {
                    includeMeal = true;
                }
                tour.IncludesMeals = includeMeal;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var tour = model.Where(t => t.Id == id).FirstOrDefault();
                if (tour != null)
                {
                    model.Remove(tour);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Tour/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var tour = model.Where(t => t.Id == id).FirstOrDefault();
                if (tour != null)
                {
                    model.Remove(tour);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}