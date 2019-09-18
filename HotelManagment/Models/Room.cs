using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    
    public class Room
    {
      public   int Id { get; set; }

      
        public string Status { get; set; }

        [Display(Name = "Otagin Nomresi")]
        [Required(ErrorMessage ="Nomreni daxil edin")]
        public int RoomNo { get; set; }

        [Display(Name = "Otagin qiymeti")]
        [Required]
        [Column(TypeName = "money")]
        public decimal DailyPrice { get; set; }


        [Display(Name = "Otaqdaki Yetiskin sayi")]
        [Required(ErrorMessage = "Yetishkin sayisini daxil edin")]
        public int PersonCapacity { get; set; }


        [Display(Name = "Otaqdaki Usaq sayi")]
        [Required(ErrorMessage ="Usaq sayisini daxil edin")]
        public int ChildCapacity { get; set; }



        [Display(Name = "Yataqlarin novu")]
        public int BedTypeId { get; set; }


        public BedType BedType { get; set; }

       
        public string Photo { get; set; }

        [Display(Name = "Otagin fotosu")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Otaq haqqinda melumat")]
        [Required(ErrorMessage = "Description Yazin"), MaxLength(50)]
        public string Desc { get; set; }

        public List<Booking> Bookings { get; set; }

        public bool? IsDelete { get; set; }



       public List<ResturantOrder> ResturantOrders { get; set; }
    }
}