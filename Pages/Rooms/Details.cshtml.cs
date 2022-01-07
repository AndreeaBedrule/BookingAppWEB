using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingAppWEB.Data;
using BookingAppWEB.Models;

namespace BookingAppWEB.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly BookingAppWEB.Data.BookingAppWEBContext _context;

        public DetailsModel(BookingAppWEB.Data.BookingAppWEBContext context)
        {
            _context = context;
        }

        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room.FirstOrDefaultAsync(m => m.ID == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
