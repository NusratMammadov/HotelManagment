using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class ResturantOrder
    {
        public int Id { get; set; }

        [Display(Name = "Musterinin melumatlari")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Mehsulun melumatlari")]
        public int FoodId { get; set; }

        public Food Food { get; set; }

        [Display(Name = "Mehsulun miqdari")]
        [Required]
        public int FoodCount { get; set; }


        [Display(Name = "Sifarisin cemi meblegi")]
        [Required]
        [Column(TypeName = "money")]
        public decimal FoodOrderTotalPrice { get; set; }

        [Display(Name = "Sifariscinin otaq nomresi")]
        public int RoomId { get; set; }

        public Room Room { get; set; }

        public bool? IsDelete { get; set; }

        [Display(Name = "Sifarisi goturenin melumatlari")]
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }
        
    }
}