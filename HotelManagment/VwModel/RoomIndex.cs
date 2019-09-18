using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagment.Models;

namespace HotelManagment.VwModel
{
    public class RoomIndex
    {
        public List<Room> Rooms { get; set; }

        public List<BedType> bedTypes { get; set; }

    }
}