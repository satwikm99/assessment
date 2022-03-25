using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Product { get; set; }
        public string Address { get; set; }
        public long PhoneNo { get; set; }
    }
}