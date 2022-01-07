using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingAppWEB.Data;
using BookingAppWEB.Models;

namespace BookingAppWEB.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly BookingAppWEB.Data.BookingAppWEBContext _context;

        public CreateModel(BookingAppWEB.Data.BookingAppWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "UserName");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
