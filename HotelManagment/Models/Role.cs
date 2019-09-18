using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Display(Name = "Iscinin Vezifesi")]
        public string RoleName { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}