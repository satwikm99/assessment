using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopManagementSystems.Models
{
    public class CustomerLedger
    {
        public int InvoicePaymentID { get; set; }
        public string InvoiceID { get; set; }
        public int GrandTotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int DueAmount { get; set; }
        public int BalanceAmount { get; set; }
    }
}