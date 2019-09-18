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
    public class BedTypeController : Controller
    {
        private readonly HotelContext _context;

        public BedTypeController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            var list = _context.bedTypes.OrderByDescending(p => p.Id).ToList();
            return View(list);

        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            ViewBag.BedTypes = _context.bedTypes.ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create(BedType bedType)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {

                


                _context.bedTypes.Add(bedType);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(bedType);
        }

        

       

        public ActionResult Delete(int Id)
        {
            BedType bedType = _context.bedTypes.Find(Id);

            if (bedType == null)
            {

                return HttpNotFound();
            }

            
            _context.bedTypes.Remove(bedType);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}