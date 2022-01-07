using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAppWEB.Models
{
    public class ReservationData
    {
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<ReservationRoom> ReservationRooms { get; set; }
    }
}
