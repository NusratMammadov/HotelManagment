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
    public class FoodController : Controller
    {

        private readonly HotelContext _context;

        public FoodController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Foods.Include("FoodCategory").OrderByDescending(p => p.Id).ToList();
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
        public ActionResult Create(Food food)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {

              


                _context.Foods.Add(food);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(food);
        }

        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Food food = _context.Foods.Find(Id);

            if (food == null)
            {

                return HttpNotFound();
            }

            ViewBag.FoodCategories = _context.FoodCategories.ToList();

            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {

            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            if (ModelState.IsValid)
            {



                
                _context.Entry(food).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.BedTypes = _context.bedTypes.ToList();


            return View(food);
        }

        public ActionResult Delete(int Id)
        {
            Food food = _context.Foods.Find(Id);

            if (food == null)
            {

                return HttpNotFound();
            }

           
            _context.Foods.Remove(food);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}