using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingAppWEB.Data;

namespace BookingAppWEB.Models
{
    public class ReservationRoomsPageModel : PageModel
    {
        public List<AssignedRoomData> AssignedRoomDataList;
        public void PopulateAssignedRoomData(BookingAppWEBContext context,
        Reservation reservation)
        {
            var allRooms = context.Room;
            var reservationRooms = new HashSet<int>(
            reservation.ReservationRooms.Select(c => c.RoomID)); //
            AssignedRoomDataList = new List<AssignedRoomData>();
            foreach (var cat in allRooms)
            {
                AssignedRoomDataList.Add(new AssignedRoomData
                {
                    RoomID = cat.ID,
                    Name = cat.RoomType,
                    Assigned = reservationRooms.Contains(cat.ID)
                });
            }
        }
        public void UpdateReservationRooms(BookingAppWEBContext context,
        string[] selectedRooms, Reservation reservationToUpdate)
        {
            if (selectedRooms == null)
            {
                reservationToUpdate.ReservationRooms = new List<ReservationRoom>();
                return;
            }
            var selectedRoomsHS = new HashSet<string>(selectedRooms);
            var reservationRooms = new HashSet<int>
            (reservationToUpdate.ReservationRooms.Select(c => c.Room.ID));
            foreach (var cat in context.Room)
            {
                if (selectedRoomsHS.Contains(cat.ID.ToString()))
                {
                    if (!reservationRooms.Contains(cat.ID))
                    {
                        reservationToUpdate.ReservationRooms.Add(
                        new ReservationRoom
                        {
                            ReservationID = reservationToUpdate.ID,
                            RoomID = cat.ID
                        });
                    }
                }
                else
                {
                    if (reservationRooms.Contains(cat.ID))
                    {
                        ReservationRoom courseToRemove
                        = reservationToUpdate
                        .ReservationRooms
                       .SingleOrDefault(i => i.RoomID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
