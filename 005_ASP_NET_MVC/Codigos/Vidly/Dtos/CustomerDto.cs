using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255, ErrorMessage = "The maximun string length is 255 characters.")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select the Membership Type Id.")]
        public int MembershipTypeId { get; set; }

        public override string ToString()
        {
            return "{ id:int, name:string, birthdate:Datetime, isSubscribedToNewsletter:bool, membershipTypeId:int }";
        }
    }
}