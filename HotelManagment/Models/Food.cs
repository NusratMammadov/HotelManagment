using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelManagment.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Display(Name = "Mehsulun adi")]
        [Required, MaxLength(50)]
        public string FoodName { get; set; }

        [Display(Name = "Mehsulun qiymeti")]
        [Required]
        [Column(TypeName = "money")]
        public decimal FoodPrice { get; set; }

        public bool? IsDelete { get; set; }

        [Display(Name = "Mehsulun Kateqoriyasi")]
        [Required]
        public int FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }


        public List<ResturantOrder> ResturantOrders { get; set; }
      
    }
}