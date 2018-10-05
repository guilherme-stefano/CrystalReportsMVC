using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerByMenuViewModel
    {
        public int IdMenu { get; set; }
        public int dia { get; set; }
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int productQuantity { get; set; }
    }
}