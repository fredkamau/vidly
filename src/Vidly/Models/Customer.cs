using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //navigation property-allows us to navigate from customer to membership type
        public MembershipType MembershipType  { get; set; }
        //foreign key
        public byte MembershipTypeId { get; set; }

    }
}