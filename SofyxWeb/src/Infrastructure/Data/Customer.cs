using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
