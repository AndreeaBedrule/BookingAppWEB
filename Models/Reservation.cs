using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAppWEB.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public User User { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
