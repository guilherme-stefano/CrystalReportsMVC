using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CidadeReportViewModel
    {
        public string Nome { get; set; }
        public int idCidade { get; set; }

        public virtual ICollection<CustomerReportViewModel> Customer { get; set; }
    }
}
