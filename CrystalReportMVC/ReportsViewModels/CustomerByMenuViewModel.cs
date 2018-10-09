using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerByMenuViewModel
    {
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public string productQuantitySegunda { get; set; }
        public string ProductNameSegunda { get; set; }
        public string productQuantityTerca { get; set; }
        public string ProductNameTerca { get; set; }
        public string productQuantityQuarta { get; set; }
        public string ProductNameQuarta { get; set; }
        public string productQuantityQuinta { get; set; }
        public string ProductNameQuinta { get; set; }
        public string productQuantitySexta { get; set; }
        public string ProductNameSexta { get; set; }
        public string productQuantitySabado { get; set; }
        public string ProductNameSabado { get; set; }
        public string productQuantityDomingo { get; set; }
        public string ProductNameDomingo { get; set; }

        public virtual CustomerReportViewModel Customer { get; set; }

        public bool checkHasValue()
        {
            return ProductNameSegunda != null
                || ProductNameTerca != null
                || ProductNameQuarta != null
                || ProductNameQuinta != null
                || ProductNameSexta != null
                || ProductNameSabado != null
                || ProductNameDomingo != null;
        }
    }
}