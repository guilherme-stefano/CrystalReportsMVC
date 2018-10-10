using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerByMenuProductReportViewModel
    {
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int IdMenu { get; set; }
        public string MenuDay { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float Total { get; set; }
    }
}