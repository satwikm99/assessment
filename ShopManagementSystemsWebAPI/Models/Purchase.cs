using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string Item { get; set; }
        public string SupplierDetail { get; set; }
        public long BillAmount { get; set; }
    }
}