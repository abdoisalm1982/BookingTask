using DataAccessLayer.EntityMappers;
using DataAccessLayer.Models;
using DataAccessLayer.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ApplicationDbContext
{
    public partial class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TripMap());
            modelBuilder.ApplyConfiguration(new ReservationMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>().HasData(
    new Trip { TripId = 1, Name = "Trip1", CityName = "City1", ImageUrl = "" },

    new Trip { TripId = 2, Name = "Trip2", CityName = "Cit2", ImageUrl = "" },
    new Trip { TripId = 3, Name = "Trip3", CityName = "City3", ImageUrl = "" }
);
            modelBuilder.Entity<User>().HasData(
             new User { UserId = 1, Email = "User1", Password = "123456" },
                     new User { UserId = 2, Email = "User2", Password = "123456789" }
         );
            modelBuilder.Entity<Reservation>().HasData(
             new Reservation { ReservedId = 1, ReservedBy = "User1", CustomerName = "ahmed", TripId = 1, ReservationDate = DateTime.Now, Notes = "Test1" },
             new Reservation { ReservedId = 2, ReservedBy = "User2", CustomerName = "Islam", TripId = 2, ReservationDate = DateTime.Now, Notes = "Test2" }


         );
           // modelBuilder.Seed();
        }
    }
}
