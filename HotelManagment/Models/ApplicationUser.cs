using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Display(Name = "Istifadecinin Adi")]
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Istifadecinin Soyadi")]
        [Required, MaxLength(50)]
        public string Surname { get; set; }

        public bool? IsDelete { get; set; }

        [Display(Name = "Istifadecinin Yasi")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "E-poçt")]
        [Required(ErrorMessage = "Email boş ola bilməz"), MaxLength(50, ErrorMessage = "Email Max 50 xarakter ola bilər")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifrə boş ola bilməz"), MaxLength(100, ErrorMessage = "Istifadəçi Adı 50 xarakter ola bilər")]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }

        public string token { get; set; }

        [Display(Name = "Istifadecinin Vezifesi")]
        [Required]
        public int RoleId {get;set;}

        public Role Role { get; set; }
        
        public List<Booking> Bookings { get; set; }

        public List<ResturantOrder> ResturantOrders { get; set; }

    }
}