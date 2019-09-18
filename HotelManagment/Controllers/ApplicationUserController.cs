using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HotelManagment.Data;
using HotelManagment.Helpers;
using HotelManagment.Models;

namespace HotelManagment.Controllers
{
    
    public class ApplicationUserController : Controller
    {
        private readonly HotelContext _context;

        public ApplicationUserController()
        {

            _context = new HotelContext();
        }

        
        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
   

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            


            var list = _context.ApplicationUsers.Include("Role").OrderByDescending(u => u.Id).ToList();

            
            return View(list);

        }

        public ActionResult Create()
        {
            
            ViewBag.Roles = _context.Roles.ToList();

            //burda qaldi


            return View();
        }

        [HttpPost]
        public ActionResult Create(ApplicationUser applicationUser)
        {

            


                if (ModelState.IsValid)
            {


                    applicationUser.Password = Crypto.HashPassword(applicationUser.Password);
                    _context.ApplicationUsers.Add(applicationUser);
                _context.SaveChanges();

                return RedirectToAction("index","applicationuser");
            }

            return View(applicationUser);
        }

        public ActionResult Edit(int Id)
        {
            
            ApplicationUser applicationUser = _context.ApplicationUsers.Find(Id);

            if (applicationUser == null)
            {

                return HttpNotFound();
            }

            ViewBag.Roles = _context.Roles.ToList();

            return View(applicationUser);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser applicationUser)
        {

            

            if (ModelState.IsValid)
            {

                


                _context.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.Roles = _context.Roles.ToList();
            //ViewBag.BedTypes = _context.bedTypes.ToList();


            return View(applicationUser);
        }

        public ActionResult Delete(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            ApplicationUser userrm = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            if (userrm.Role.RoleName != "Admin")

            {

                return HttpNotFound();

            }
            ApplicationUser applicationUser = _context.ApplicationUsers.Find(Id);

            if (applicationUser == null)
            {

                return HttpNotFound();
            }

            
            _context.ApplicationUsers.Remove(applicationUser);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}