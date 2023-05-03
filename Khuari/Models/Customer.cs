﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte? C_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customers Name")]
        [StringLength(255)]
        [Display(Name = "Enter Customer Name")]
        public string C_Name { get; set; }

        //[Display(Name = "Check for subscribed")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

       
        [Display(Name = "MembershipType")]
        public byte MembershipTypeId { get; set; }

        [MembershipTypeValidations]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }


    }
}