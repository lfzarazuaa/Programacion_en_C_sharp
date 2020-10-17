using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255,ErrorMessage = "The maximun string length is 255 characters.")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select the Membership Type Id.")]
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
        
    }
}