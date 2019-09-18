using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Musterinin Adi")]
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Musterinin Soyadi")]
        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Musterinin Yasi")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Musterinin Passport Nomresi")]
        [Required]
        public int PassportNo { get; set; }

        [Display(Name = "Musterinin Odeyeceyi Mebleg")]
        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPayment { get; set; }

        public bool? IsDelete { get; set; }


        public List<Booking> Bookings { get; set; }

        public List<ResturantOrder> ResturantOrders { get; set; }

    }
}