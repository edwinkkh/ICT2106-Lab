using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Models
{
    public class ExploreCaliforniaContext : DbContext
    {
        public ExploreCaliforniaContext (DbContextOptions<ExploreCaliforniaContext> options)
            : base(options)
        {
        }

        public DbSet<ExploreCalifornia.Models.Tour> Tour { get; set; }

        public DbSet<ExploreCalifornia.Models.Booking> Booking { get; set; }
    }
}
