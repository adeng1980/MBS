using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBookingProject.Models
{
    public class BookingTable
    {
        public int Id { get; set; }
        public string seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Datetopresent { get; set; }
        [ForeignKey("MovieDetailsId")]
        public int MovieDetailsId { get; set; }
        public int Amount { get; set; }



    }
}
