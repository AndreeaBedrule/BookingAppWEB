using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAppWEB.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
