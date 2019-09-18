using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class BedType
    {
        public int Id { get; set; }

        [Display(Name = "Yatagin novu")]
        public string Type { get; set; }

        public List<Room> Rooms { get; set; }
    }
}