using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAppWEB.Models
{
    public class AssignedRoomData
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
