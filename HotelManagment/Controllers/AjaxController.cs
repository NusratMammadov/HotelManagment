using HotelManagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagment.Models;
using System.Net;
using HotelManagment.Helpers;

namespace HotelManagment.Controllers
{
    [Auth]
    public class AjaxController : Controller
    {

        private readonly HotelContext _context;

        public AjaxController()
        {
           

            _context = new HotelContext();
        }

        // GET: Ajax
        public ActionResult SearchRoom(int Id)
        {

            string cookie = Request.Cookies["cookie"].Value.ToString();


            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            var rooms = _context.Rooms.Include("BedType").Where(r=>r.IsDelete==false).Where(r => r.BedTypeId == Id).ToList();



            return View("_RoomList",rooms);
        }

        public ActionResult Active(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();


            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            var room = _context.Rooms.Find(id);

            room.IsDelete = true;

            _context.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }
    }
}