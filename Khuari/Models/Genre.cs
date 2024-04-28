using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class Genre
    {
        [Key]
        public int G_Id { get; set; }

        public string G_Name { get; set; }


        

    }
}