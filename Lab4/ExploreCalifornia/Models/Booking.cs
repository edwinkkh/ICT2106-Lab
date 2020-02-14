using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int TourID { get; set; }
        public string TourName { get; set; }
        public string ClientID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }
        public int NumberOfPeople { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string SpecialRequest { get; set; }
    }
}
