﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    { 
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //navigation property-allows us to navigate from customer to membership type
        [Required]
        public MembershipType MembershipType { get; set; }
        //foreign key
        [Display(Name ="Membership Type")]  
        [Min18YearsIfAMember]
        public byte MembershipTypeId { get; set; }

    }
}