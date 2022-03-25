using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class ProductPurchase
    {
        public string ItemID { get; set; }
        public string ProductName { get; set; }
        public string Department { get; set; }
        public int Size { get; set; }
        public  string Length { get; set; }
        public int Price { get; set; }
    }
}