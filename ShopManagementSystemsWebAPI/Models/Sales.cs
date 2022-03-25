using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class Sales
    {
        public int SalesID { get; set; }
        public string Item { get; set; }
        public string CustomerDetail { get; set; }
        public long BillAmount { get; set; }
    }
}