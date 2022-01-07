using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAppWEB.Models
{
    public class ReservationRoom
    {
        public int ID { get; set; }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
