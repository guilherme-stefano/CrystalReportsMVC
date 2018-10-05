using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class MenuProdutoReportViewModel
    {
        public int Id { get; set; }
        public int IdMenu { get; set; }
        public int IdProduto { get; set; }

        public MenuReportViewModel Menu { get; set; }
        public ProdutoReportViewModel Produto { get; set; }
    }
}