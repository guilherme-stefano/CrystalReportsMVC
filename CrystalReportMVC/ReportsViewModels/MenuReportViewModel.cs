using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class MenuReportViewModel
    {
        public int id { get; set; }
        public int dia { get; set; }

        public  ICollection<CustomerMenuReportViewModel> CustomerMenu { get; set; }
        public  ICollection<MenuProdutoReportViewModel> MenuProduto { get; set; }
    }
}