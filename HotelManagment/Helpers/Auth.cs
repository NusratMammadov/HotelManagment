using HotelManagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagment.Models;
using System.Web.Routing;

namespace HotelManagment.Helpers
{
    public class Auth: ActionFilterAttribute
    {

        private readonly HotelContext _context;
        public Auth()
        {
            _context = new HotelContext();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Request.Cookies["cookie"] == null)
            {
                filterContext.Result = new RedirectResult("/Login");
                return;
            }
            

            string token = HttpContext.Current.Request.Cookies["cookie"].Value.ToString();
            ApplicationUser applicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.token == token);

            if (applicationUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Login" },
                    { "action", "Index" }
               });
            }


        }

    }
}