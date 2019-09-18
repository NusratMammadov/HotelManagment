using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagment.Data;
using HotelManagment.Helpers;
using HotelManagment.Models;
using HotelManagment.VwModel;

namespace HotelManagment.Controllers
{
    [Auth]
    public class RoomController : Controller
    {
        private readonly HotelContext _context;

        public RoomController()
        {

            _context = new HotelContext();
        }

        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();


            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            //var list = _context.Rooms.Include("BedType").OrderByDescending(p => p.Id).ToList();

            RoomIndex roomvw = new RoomIndex
            {
                Rooms = _context.Rooms.Include("BedType").OrderByDescending(p => p.Id).ToList(),
                bedTypes = _context.bedTypes.ToList(),

        };
            return View(roomvw);

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
        public ActionResult Create(Room room)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();


            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (ModelState.IsValid)
            {

                room.Photo = FileManager.Upload(room.File);

                room.IsDelete = false;
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            return View(room);
        }

        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();


            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            Room room = _context.Rooms.Find(Id);

            if (room == null)
            {

                return HttpNotFound();
            }

            ViewBag.BedTypes = _context.bedTypes.ToList();

            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();

            ApplicationUser user = _context.ApplicationUsers.Include("Role").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (room.File != null)
            {

                if (room.File.ContentLength / 1024 / 1024 > 1)
                {

                    ModelState.AddModelError("File", "Max 1 Mb");
                }


            }

            if (ModelState.IsValid)
            {

                if (room.File != null)
                {
                    FileManager.Delete(room.Photo);

                    room.Photo = FileManager.Upload(room.File);
                }
                

                _context.Entry(room).State = System.Data.Entity.EntityState.Modified;

                _context.SaveChanges();


                return RedirectToAction("index");
            }


            ViewBag.BedTypes = _context.bedTypes.ToList();


            return View(room);
        }

        public ActionResult Delete(int Id)
        {

            Room room = _context.Rooms.Find(Id);

            if (room == null)
            {

                return HttpNotFound();
            }

            FileManager.Delete(room.Photo);
            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }

}