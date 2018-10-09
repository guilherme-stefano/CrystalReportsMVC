using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.ReportsViewModels
{
    public class CustomerByMenuViewModel2
    {
        public CustomerByMenuViewModel2()
        {
            this.produtosSegunda = new List<MenuProdutoReportViewModel>();
            this.produtosTerca = new List<MenuProdutoReportViewModel>();
            this.produtosQuarta = new List<MenuProdutoReportViewModel>();
            this.produtosQuinta = new List<MenuProdutoReportViewModel>();
            this.produtosSexta = new List<MenuProdutoReportViewModel>();
            this.produtosSabado = new List<MenuProdutoReportViewModel>();
            this.produtosDomingo = new List<MenuProdutoReportViewModel>();
        }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int maxQuantity { get; set; }
        public List<MenuProdutoReportViewModel> produtosSegunda { get; set; }
        public List<MenuProdutoReportViewModel> produtosTerca { get; set; }
        public List<MenuProdutoReportViewModel> produtosQuarta { get; set; }
        public List<MenuProdutoReportViewModel> produtosQuinta { get; set; }
        public List<MenuProdutoReportViewModel> produtosSexta { get; set; }
        public List<MenuProdutoReportViewModel> produtosSabado { get; set; }
        public List<MenuProdutoReportViewModel> produtosDomingo { get; set; }
    }
}