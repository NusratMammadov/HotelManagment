using HotelManagment.Data;
using HotelManagment.Helpers;
using HotelManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagment.Controllers
{
    [Auth]
    public class FoodCategoryController : Controller
    {

        private readonly HotelContext _context;

        public FoodCategoryController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.FoodCategories.OrderByDescending(p => p.Id).ToList();
            return View(list);

        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.FoodCategories = _context.FoodCategories.ToList();



            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodCategory foodCategory)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {




                _context.FoodCategories.Add(foodCategory);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(foodCategory);
        }





        public ActionResult Delete(int Id)
        {
            FoodCategory foodCategory = _context.FoodCategories.Find(Id);

            if (foodCategory == null)
            {

                return HttpNotFound();
            }


            _context.FoodCategories.Remove(foodCategory);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}