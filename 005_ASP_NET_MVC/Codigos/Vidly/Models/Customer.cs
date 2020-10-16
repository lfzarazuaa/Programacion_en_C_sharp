﻿using System;
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
        
        [Required]
        [StringLength(255,ErrorMessage = "The maximun string length can be 255 characters.")]
        public string Name { get; set; }
        
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}