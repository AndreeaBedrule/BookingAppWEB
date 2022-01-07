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

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation.Include(b => b.User).ToListAsync();
        }
    }
}
