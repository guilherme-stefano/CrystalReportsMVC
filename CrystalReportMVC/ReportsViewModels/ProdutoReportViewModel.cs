using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class ProdutoReportViewModel
    {

        public int id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<MenuProdutoReportViewModel> MenuProduto { get; set; }
    }
}