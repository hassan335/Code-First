using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class Movie
    {
        



        [Key]
        public int M_Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name is required")]
        [StringLength(255)]
        public string M_Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }


        [Range(1, 20, ErrorMessage = "Min 1 , Max20 ")]
        [Display(Name = "Number In Stock")]
        public short NumberInStockk { get; set; }

        public short NumberAvaliable { get; set; }



        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Please Select Gener")]
        [Display (Name ="Gener")]
         
        public int G_Id { get; set; }

        
    }
}