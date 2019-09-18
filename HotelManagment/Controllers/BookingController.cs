using HotelManagment.Data;
using HotelManagment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagment.Controllers
{
    public class BookingController : Controller
    {

        private readonly HotelContext _context;

        public BookingController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Bookings.Include("ApplicationUser").Include("Customer").Include("Room").OrderByDescending(p => p.Id).ToList();

            return View(list);

        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.ApplicationUsers = _context.ApplicationUsers.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var room = _context.Rooms.Find(booking.RoomId);

            System.TimeSpan diff = booking.EndDate.Subtract(booking.StartDate);

            
            

            

            booking.Price = diff.Days * room.DailyPrice;

           




            if (ModelState.IsValid)
            {
                

                _context.Bookings.Add(booking);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.ApplicationUsers = _context.ApplicationUsers.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();

            return View(booking);
        }

        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Booking booking = _context.Bookings.Find(Id);

            if (booking == null)
            {

                return HttpNotFound();
            }

            ViewBag.ApplicationUsers = _context.ApplicationUsers.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();

            return View(booking);
        }

        [HttpPost]
        public ActionResult Edit(Booking booking)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {
                ViewBag.ApplicationUsers = _context.ApplicationUsers.ToList();
                ViewBag.Customers = _context.Customers.ToList();
                ViewBag.Rooms = _context.Rooms.ToList();

                var room = _context.Rooms.Find(booking.RoomId);

                System.TimeSpan diff = booking.EndDate.Subtract(booking.StartDate);


                booking.Price = diff.Days * room.DailyPrice;

                _context.Entry(booking).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.ApplicationUsers = _context.ApplicationUsers.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();

            return View(booking);
        }

        public ActionResult Delete(int Id)
        {
            Booking booking = _context.Bookings.Find(Id);

            if (booking == null)
            {

                return HttpNotFound();
            }


            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}