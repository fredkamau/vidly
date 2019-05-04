using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        //id
        public byte Id { get; set; }
        //name
        [Required]
        [StringLength(255)]
        public string MembershipTypeName { get; set; }
        //signup fee
        public short SignUpFee { get; set; }
        //duration
        public byte DurationInMonths { get; set; }
        //discount rate
        public byte DiscountRate { get; set; }
    }
}