using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia.Data
{
    public class TourGateway : DataGateway<Tour>
    {
        public TourGateway(ExploreCaliforniaContext context) : base(context)
        {
            this.db = context;
        }

        public IEnumerable<Tour> SortAllByPrice()
        {
            return data.OrderBy(t => t.Price).ToList();
        }

    }
}
