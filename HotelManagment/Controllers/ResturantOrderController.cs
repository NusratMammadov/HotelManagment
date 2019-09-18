using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagment.Data;
using HotelManagment.Helpers;
using HotelManagment.Models;

namespace HotelManagment.Controllers
{
    [Auth]
    public class ResturantOrderController : Controller
    {
        private readonly HotelContext _context;

        public ResturantOrderController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.ResturantOrders.Include("Customer").Include("ApplicationUser").Include("Food").Include("Room").OrderByDescending(p => p.Id).ToList();
            

            return View(list);

        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();
            ViewBag.ApplicationUser = _context.ApplicationUsers.ToList();
            ViewBag.Foods = _context.Foods.ToList();



            return View();
        }

        [HttpPost]
        public ActionResult Create(ResturantOrder resturantOrder)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var food = _context.Foods.Find(resturantOrder.FoodId);

            resturantOrder.FoodOrderTotalPrice = food.FoodPrice * resturantOrder.FoodCount;








            if (ModelState.IsValid)
            {

               

                _context.ResturantOrders.Add(resturantOrder);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(resturantOrder);
        }

        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ResturantOrder resturantOrder = _context.ResturantOrders.Find(Id);

            if (resturantOrder == null)
            {

                return HttpNotFound();
            }



            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();
            ViewBag.ApplicationUser = _context.ApplicationUsers.ToList();
            ViewBag.Foods = _context.Foods.ToList();

            return View(resturantOrder);
        }

        [HttpPost]
        public ActionResult Edit(ResturantOrder resturantOrder)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {
                var food = _context.Foods.Find(resturantOrder.FoodId);

                resturantOrder.FoodOrderTotalPrice = food.FoodPrice * resturantOrder.FoodCount;



                _context.Entry(resturantOrder).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.BedTypes = _context.bedTypes.ToList();


            return View(resturantOrder);
        }

        public ActionResult Delete(int Id)
        {
            ResturantOrder resturantOrder = _context.ResturantOrders.Find(Id);

            if (resturantOrder == null)
            {

                return HttpNotFound();
            }


            _context.ResturantOrders.Remove(resturantOrder);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}