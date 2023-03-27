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
        [Required]
        [StringLength(255)]
        public string M_Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public short NumberInStockk { get; set; }

        public Genre Genre { get; set; }

        public int G_Id { get; set; }


    }
}