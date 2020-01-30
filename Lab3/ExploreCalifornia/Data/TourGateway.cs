using ExploreCalifornia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Data
{
    public class TourGateway: DateGateway<Tour>
    {
        private readonly ExploreCaliforniaContext db;

        public TourGateway(ExploreCaliforniaContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Tour>> SelectAll()
        {
            return await db.Tour.ToListAsync();
        }

        public async Task<Tour> SelectById(int? id)
        {
           var tour = await db.Tour.FirstOrDefaultAsync(m => m.Id == id);
        
            return tour;
        }

        public Tour Insert(Tour tour)
        {
            db.Add(tour);
            db.SaveChanges();
            return tour;
        }

        public Tour Update(Tour tour)
        {
            db.Update(tour);
            db.SaveChanges();

            return tour;
        }

        public Tour Delete(int? id) {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
            db.SaveChanges();
            return tour;
        }

        public bool Exist(int? id)
        {
            return db.Tour.Any(e => e.Id == id);
        }
    }
}
