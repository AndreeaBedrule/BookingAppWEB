using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookingAppWEB.Models;

namespace BookingAppWEB.Data
{
    public class BookingAppWEBContext : DbContext
    {
        public BookingAppWEBContext (DbContextOptions<BookingAppWEBContext> options)
            : base(options)
        {
        }

        public DbSet<BookingAppWEB.Models.Reservation> Reservation { get; set; }

        public DbSet<BookingAppWEB.Models.User> User { get; set; }

        public DbSet<BookingAppWEB.Models.Room> Room { get; set; }
    }
}
