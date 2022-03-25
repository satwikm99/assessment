using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class ProductSales
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int HSNNumber { get; set; }
        public string Unit { get; set; }
        public int SalesPrice { get; set; }
        public string GST { get; set; }
    }
}