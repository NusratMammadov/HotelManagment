using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HotelManagment.Models;

namespace HotelManagment.Data
{
    public class HotelContext:DbContext
    {
        public HotelContext() : base("HotelContext")
        {


        }

        

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<BedType> bedTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }    

        public DbSet<ResturantOrder> ResturantOrders { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }

    }
}