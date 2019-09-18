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
    public class CustomerController : Controller
    {
        private readonly HotelContext _context;

        public CustomerController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.Customers.OrderByDescending(p => p.Id).ToList();

            return View(list);

        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;


            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;


            if (ModelState.IsValid)
            {

               


                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(customer);
        }

        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Customer customer = _context.Customers.Find(Id);

            if (customer == null)
            {

                return HttpNotFound();
            }

            

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            if (ModelState.IsValid)
            {

                


                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("index");
            }


           


            return View(customer);
        }

        public ActionResult Delete(int Id)
        {
            Customer customer = _context.Customers.Find(Id);

            if (customer == null)
            {

                return HttpNotFound();
            }

           
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}