using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAppWEB.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }

        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
