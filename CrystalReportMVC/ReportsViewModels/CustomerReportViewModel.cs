using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerReportViewModel
    {
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerZipCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public ICollection<CustomerMenuReportViewModel> CustomerMenu { get; set; }
    }
}