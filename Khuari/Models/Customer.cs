using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class Customer
    {
        [Key]
        public int C_Id { get; set; }

        public string C_Name { get; set; }



    }
}