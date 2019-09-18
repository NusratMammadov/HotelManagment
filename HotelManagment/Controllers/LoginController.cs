using HotelManagment.Data;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;
using HotelManagment.VwModel;
using HotelManagment.Models;
using System.Web;
using HotelManagment.Helpers;

namespace HotelManagment.Controllers
{
   
    public class LoginController : Controller
    {

        public readonly HotelContext _context;

        public LoginController()
        {
            _context = new HotelContext();
        }


        
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.Email == login.Email);
                if (applicationUser != null)
                {
                    if (Crypto.VerifyHashedPassword(applicationUser.Password, login.Password))
                    {
                        var g = Guid.NewGuid().ToString();
                        applicationUser.token = g;
                        _context.SaveChanges();

                        Response.Cookies["cookie"].Value = applicationUser.token;
                        Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(1);
                        return RedirectToAction("index", "booking");
                    }
                }
                else
                {
                    ModelState.AddModelError("Summary", "E-poçt və ya Şifrə yanlışdır");
                }
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["cookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cookie");
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index", "login");
        }

    }
}