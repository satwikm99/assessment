using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class SupplierLedger
    {
        public int SupplierPaymentID { get; set; }
        public string ChalanID { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int DueAmount { get; set; }
        public int BalanceAmount { get; set; }
    }
}