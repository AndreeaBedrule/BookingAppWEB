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
    public class CreateModel : ReservationRoomsPageModel

    {
        private readonly BookingAppWEB.Data.BookingAppWEBContext _context;

        public CreateModel(BookingAppWEB.Data.BookingAppWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "UserName");
            var reservation = new Reservation();
            reservation.ReservationRooms = new List<ReservationRoom>();
            PopulateAssignedRoomData(_context, reservation);
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedRooms)
        {
            var newReservation = new Reservation();
            if (selectedRooms != null)
            {
                newReservation.ReservationRooms = new List<ReservationRoom>();
                foreach (var cat in selectedRooms)
                {
                    var catToAdd = new ReservationRoom
                    {
                        RoomID = int.Parse(cat)
                    };
                    newReservation.ReservationRooms.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Reservation>(
            newReservation,
            "Reservation",
            i => i.UserID, i => i.CheckIn,
            i => i.CheckOut, i => i.User))
            {
                _context.Reservation.Add(newReservation);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedRoomData(_context, newReservation);
            return Page();
        }
    }
}
