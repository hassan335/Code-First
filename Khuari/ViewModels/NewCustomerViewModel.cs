using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuari.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }

        public Customer customer { get; set; }



    }
}