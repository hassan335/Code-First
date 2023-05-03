using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignupFee { get; set; }

        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
     


    }
}