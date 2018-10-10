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
        public float productValueSegunda { get; set; }
        public int productQuantitySegunda { get; set; }
        public string productQuantitySegunda_str { get; set; }
        public string ProductNameSegunda { get; set; }
        public float productValueTerca { get; set; }
        public int productQuantityTerca { get; set; }
        public string productQuantityTerca_str { get; set; }
        public string ProductNameTerca { get; set; }
        public float productValueQuarta { get; set; }
        public int productQuantityQuarta { get; set; }
        public string productQuantityQuarta_str { get; set; }
        public string ProductNameQuarta { get; set; }
        public float productValueQuinta { get; set; }
        public int productQuantityQuinta { get; set; }
        public string productQuantityQuinta_str { get; set; }
        public string ProductNameQuinta { get; set; }
        public float productValueSexta { get; set; }
        public int productQuantitySexta { get; set; }
        public string productQuantitySexta_str { get; set; }
        public string ProductNameSexta { get; set; }
        public float productValueSabado { get; set; }
        public int productQuantitySabado { get; set; }
        public string productQuantitySabado_str { get; set; }
        public string ProductNameSabado { get; set; }
        public float productValueDomingo { get; set; }
        public int productQuantityDomingo { get; set; }
        public string productQuantityDomingo_str { get; set; }
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