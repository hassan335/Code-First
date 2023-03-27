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

        [Required]
        [StringLength(255)]
        [Display(Name ="Enter Customer Name")]
        public string C_Name { get; set; }

        //[Display(Name = "Check for subscribed")]
        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "MembershipType")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }


    }
}