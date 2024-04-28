using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuari.DTO
{
    public class MovieDTO
    {

        //[Key]
        public int? M_Id { get; set; }

       
        public string M_Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }


      
        public short NumberInStockk { get; set; }



        public Genre Genre { get; set; }
      
        public int G_Id { get; set; }





    }
}