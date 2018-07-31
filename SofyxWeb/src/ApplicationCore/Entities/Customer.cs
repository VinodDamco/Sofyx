using System;
using System.Collections.Generic;
using System.Text;

namespace SofyxWeb.ApplicationCore.Entities
{
   public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Ipaddress { get; set; }

    }
}
