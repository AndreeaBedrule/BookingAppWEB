using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingAppWEB.Data;
using BookingAppWEB.Models;

namespace BookingAppWEB.Pages.Reservations
{
    public class EditModel : ReservationRoomsPageModel
    {
        private readonly BookingAppWEB.Data.BookingAppWEBContext _context;

        public EditModel(BookingAppWEB.Data.BookingAppWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservation.Include(b => b.User).Include(b => b.ReservationRooms).ThenInclude(b => b.Room).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            PopulateAssignedRoomData(_context, Reservation);
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "UserName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedRooms)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reservationToUpdate = await _context.Reservation.Include(i => i.User).Include(i => i.ReservationRooms).ThenInclude(i => i.Room).FirstOrDefaultAsync(s => s.ID == id);
            if (reservationToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Reservation>(
            reservationToUpdate,
            "Reservation",
            i => i.UserID, i => i.CheckIn,
            i => i.CheckOut, i => i.User))
            {
                UpdateReservationRooms(_context, selectedRooms, reservationToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateReservationRooms(_context, selectedRooms, reservationToUpdate);
            PopulateAssignedRoomData(_context, reservationToUpdate);
            return Page();
        }
    }
}

