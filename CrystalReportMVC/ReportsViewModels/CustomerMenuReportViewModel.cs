using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerMenuReportViewModel
    {
        public int id { get; set; }
        public int idCustomer { get; set; }
        public int idMenu { get; set; }

        public virtual CustomerReportViewModel Customer { get; set; }
        public virtual MenuReportViewModel Menu { get; set; }
    }
}