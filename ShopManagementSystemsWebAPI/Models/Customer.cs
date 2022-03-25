using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerCompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
    }
}