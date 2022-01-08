using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingAppWEB.Data;
using BookingAppWEB.Models;

namespace BookingAppWEB.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly BookingAppWEB.Data.BookingAppWEBContext _context;

        public IndexModel(BookingAppWEB.Data.BookingAppWEBContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public ReservationData ReservationD { get; set; }
        public int ReservationID { get; set; }
        public int RoomID { get; set; }
        public async Task OnGetAsync(int? id, int? roomID)
        {
            ReservationD = new ReservationData();

            ReservationD.Reservations = await _context.Reservation.Include(b => b.User).Include(b => b.ReservationRooms).ThenInclude(b => b.Room).AsNoTracking().ToListAsync();
            if (id != null)
            {
                ReservationID = id.Value;
                Reservation reservation = ReservationD.Reservations.Where(i => i.ID == id.Value).Single();
                ReservationD.Rooms = reservation.ReservationRooms.Select(s => s.Room);
            }
        }
    }
}
