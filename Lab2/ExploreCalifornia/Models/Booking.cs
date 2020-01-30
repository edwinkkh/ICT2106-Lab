using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int TourID { get; set; }
        public string TourName { get; set; }
        public int ClientID { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberOfPeople { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string SpecialRequest { get; set; }
    }
}
