using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Data;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Data
{
    public class BookingGateway : DataGateway<Booking>
    {
        public BookingGateway(ExploreCaliforniaContext context) : base(context)
        {
            //this.db = context;
        }
    }
}
