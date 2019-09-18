using HotelManagment.Data;
using HotelManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagment.Controllers
{
    public class RoleController : Controller
    {
        private readonly HotelContext _context;

        public RoleController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            var list = _context.Roles.OrderByDescending(p => p.Id).ToList();
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
        public ActionResult Create(Role role)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {




                _context.Roles.Add(role);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(role);
        }





        public ActionResult Delete(int Id)
        {
            Role role = _context.Roles.Find(Id);

            if (role == null)
            {

                return HttpNotFound();
            }


            _context.Roles.Remove(role);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}