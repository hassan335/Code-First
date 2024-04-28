using Khuari.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Khuari.DTO
{
    public class CustomerDTO
    {
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte? C_Id { get; set; }

        //[Required(ErrorMessage = "Please Enter Customers Name")]
        //[StringLength(255)]
        
        public string C_Name { get; set; }

        //[Display(Name = "Check for subscribed")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }



        public byte MembershipTypeId { get; set; }

        //[MembershipTypeValidations]
       
        public DateTime? DOB { get; set; }



    }
}