using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class Booking
    {

        public int Id { get; set; }

        //public int RoomId { get; set; }

        //public Room Room { get; set; }

        [Display(Name = "Istifadeci")]
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Musteri")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
        public bool? IsDeleted { get; set; }

        [Display(Name = "Otaq Melumatlari")]
        public int RoomId { get; set; }
        public Room Room { get; set; }


        public List<ResturantOrder> ResturantOrders { get; set; }



    }
}