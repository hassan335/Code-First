using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Khuari.Models
{
    public class MembershipTypeValidations:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                var customer = (Customer)validationContext.ObjectInstance;

                if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                {
                    return ValidationResult.Success;
                }
                else
                {

                    if (customer.DOB == null)
                    {
                        return new ValidationResult("DOB is required");
                    }
                    else
                    {
                        var age = DateTime.Today.Year - customer.DOB.Value.Year;

                        return (age >= 18)
                            ? ValidationResult.Success
                            : new ValidationResult("age is must be greater than 18");
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


          
        }


    }
}