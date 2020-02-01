using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;
using ExploreCalifornia.Data;

namespace ExploreCalifornia.Controllers
{
    public class ToursController : GeneralController<Tour>
    {
        private TourGateway tourGateway;
        List<SelectListItem> items = new List<SelectListItem>();

        public ToursController(ExploreCaliforniaContext context) : base(context)
        {
            //_context = context;
            tourGateway = new TourGateway(context);
        }

        // GET: Tours
        public override IActionResult Index(int? value)
        {
            //return View(await _context.Tour.ToListAsync());
            //List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item = new SelectListItem() { Text = "", Value = "4", Selected = true };
            SelectListItem item1 = new SelectListItem() { Text = "All", Value = "0", Selected = false };
            SelectListItem item2 = new SelectListItem() { Text = "$0-$1000", Value = "1", Selected = false };
            SelectListItem item3 = new SelectListItem() { Text = "$1000-$5000", Value = "2", Selected = false };
            SelectListItem item4 = new SelectListItem() { Text = "Above $5000", Value = "3", Selected = false };
            items.Add(item);
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            ViewBag.PriceRange = items;

            if (value != null)
            {
                switch (value)
                {
                    case 0:
                        return View(tourGateway.SelectAll());
                    case 1:
                        return View(from row in tourGateway.db.Tour where (row.Price <= 1000) select row);
                    case 2:
                        return View(from row in tourGateway.db.Tour where ((row.Price >= 1000) && (row.Price <= 5000)) select row);
                    case 3:
                        return View(from row in tourGateway.db.Tour where (row.Price >= 5000) select row);
                    case 4:
                        return View("Index", tourGateway.SortAllByPrice());
                    default:
                        break;
                }
            }


            return View(tourGateway.SelectAll());
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Create([Bind("Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourGateway.Insert(tour);
                var newlyCreatedId = tour.Id;
                return RedirectToAction(nameof(Confirm), new { id = newlyCreatedId });
            }
            return View(tour);
        }
    }
}
