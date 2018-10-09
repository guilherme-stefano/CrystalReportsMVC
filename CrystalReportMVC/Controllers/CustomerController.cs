using AutoMapper;
using CrystalDecisions.CrystalReports.Engine;
using CrystalReportMVC.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrystalReportMVC.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDBEntities context = new CustomerDBEntities();
        public ActionResult Index()
        {
            var customerList = context.Customer.ToList();
            return View(customerList);
        }

        public ActionResult ExportCustomers()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);
            ReportDocument rd = new ReportDocument();
            var combined = Path.Combine(Server.MapPath("~/CrystalReports"), "Customer.rpt");
            rd.Load(combined);

            rd.SetDataSource(customerModel);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            rd.Close();
            rd.Dispose();

            return File(stream, "application/pdf", "CustomerList.pdf");
        }

        public ActionResult ExportCustomersFromDB()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);
            ReportDocument rd = new ReportDocument();
            var combined = Path.Combine(Server.MapPath("~/CrystalReports"), "ReportFromDB.rpt");
            rd.Load(combined);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }

        public ActionResult ExportMenuByCustomer2()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);
            List<CustomerByMenuViewModel2> customerByMenuReport = new List<CustomerByMenuViewModel2>();
            foreach (var customer in customerModel)
            {
                CustomerByMenuViewModel2 customerReport = new CustomerByMenuViewModel2();
                foreach (var customerMenu in customer.CustomerMenu)
                {
                    var menu = customerMenu.Menu;
                    int size = 0;
                    customerReport.CustomerName = customer.CustomerName;
                    customerReport.IdCustomer = customer.id;
                    foreach (var produtoMenu in menu.MenuProduto)
                    {
                        var count = 0;
                        switch (menu.dia)
                        {
                            case 1:
                                customerReport.produtosDomingo.Add(produtoMenu);
                                count = customerReport.produtosDomingo.Count();
                                break;
                            case 2:
                                customerReport.produtosSegunda.Add(produtoMenu);
                                count = customerReport.produtosSegunda.Count();
                                break;
                            case 3:
                                customerReport.produtosTerca.Add(produtoMenu);
                                count = customerReport.produtosTerca.Count();
                                break;
                            case 4:
                                customerReport.produtosQuarta.Add(produtoMenu);
                                count = customerReport.produtosQuarta.Count();
                                break;
                            case 5:
                                customerReport.produtosQuinta.Add(produtoMenu);
                                count = customerReport.produtosQuinta.Count();
                                break;
                            case 6:
                                customerReport.produtosSexta.Add(produtoMenu);
                                count = customerReport.produtosSexta.Count();
                                break;
                            case 7:
                                customerReport.produtosSabado.Add(produtoMenu);
                                count = customerReport.produtosSabado.Count();
                                break;

                        }
                        size = count > size ? count : size;
                    }
                    customerReport.maxQuantity = size;
                }
                customerByMenuReport.Add(customerReport);
            }
            List<CustomerByMenuViewModel> report = new List<CustomerByMenuViewModel>();
            foreach (var customerList in customerByMenuReport)
            {
                for (int i = 0; i < customerList.maxQuantity; i++)
                {
                    CustomerByMenuViewModel customerReport = new CustomerByMenuViewModel();
                    customerReport.IdCustomer = customerList.IdCustomer;
                    customerReport.CustomerName = customerList.CustomerName;
                    var domingo = customerList.produtosDomingo.ElementAtOrDefault(i);
                    customerReport.ProductNameDomingo = domingo != null ? domingo.Produto.Nome : "";
                    customerReport.productQuantityDomingo = domingo != null ? domingo.quantidade.ToString() : "";
                    var segunda = customerList.produtosSegunda.ElementAtOrDefault(i);
                    customerReport.ProductNameSegunda = segunda != null ? segunda.Produto.Nome : "";
                    customerReport.productQuantitySegunda = segunda != null ? segunda.quantidade.ToString() : "";
                    var terca = customerList.produtosTerca.ElementAtOrDefault(i);
                    customerReport.ProductNameTerca = terca != null ? terca.Produto.Nome : "";
                    customerReport.productQuantityTerca = terca != null ? terca.quantidade.ToString() : "";
                    var quarta = customerList.produtosQuarta.ElementAtOrDefault(i);
                    customerReport.ProductNameQuarta = quarta != null ? quarta.Produto.Nome : "";
                    customerReport.productQuantityQuarta = quarta != null ? quarta.quantidade.ToString() : "";
                    var quinta = customerList.produtosQuinta.ElementAtOrDefault(i);
                    customerReport.ProductNameQuinta = quinta != null ? quinta.Produto.Nome : "";
                    customerReport.productQuantityQuinta = quinta != null ? quinta.quantidade.ToString() : "";
                    var sexta = customerList.produtosSexta.ElementAtOrDefault(i);
                    customerReport.ProductNameSexta = sexta != null ? sexta.Produto.Nome : "";
                    customerReport.productQuantitySexta = sexta != null ? sexta.quantidade.ToString() : "";
                    var sabado = customerList.produtosSabado.ElementAtOrDefault(i);
                    customerReport.ProductNameSabado = sabado != null ? sabado.Produto.Nome : "";
                    customerReport.productQuantitySabado = sabado != null ? sabado.quantidade.ToString() : "";
                    report.Add(customerReport);
                }
            }
            ReportDocument rd = new ReportDocument();
            var combined = Path.Combine(Server.MapPath("~/CrystalReports"), "CustomerByMenu.rpt");
            rd.Load(combined);

            rd.SetDataSource(report);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            rd.Close();
            rd.Dispose();

            return File(stream, "application/pdf", "MenuByCustomer.pdf");
        }

        public ActionResult ExportMenuByCustomer3()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);
            CustomerByMenuHeader header = new CustomerByMenuHeader();
            header.Frase = "Relatório de Menus Por Cliente";
            List<CustomerByMenuViewModel2> customerByMenuReport = new List<CustomerByMenuViewModel2>();
            foreach (var customer in customerModel)
            {
                header.CustomersList = header.CustomersList + customer.CustomerName + ',';
                CustomerByMenuViewModel2 customerReport = new CustomerByMenuViewModel2();
                foreach (var customerMenu in customer.CustomerMenu)
                {
                    var menu = customerMenu.Menu;
                    int size = 0;
                    customerReport.CustomerName = customer.CustomerName;
                    customerReport.IdCustomer = customer.id;
                    foreach (var produtoMenu in menu.MenuProduto)
                    {
                        var count = 0;
                        switch (menu.dia)
                        {
                            case 1:
                                customerReport.produtosDomingo.Add(produtoMenu);
                                count = customerReport.produtosDomingo.Count();
                                break;
                            case 2:
                                customerReport.produtosSegunda.Add(produtoMenu);
                                count = customerReport.produtosSegunda.Count();
                                break;
                            case 3:
                                customerReport.produtosTerca.Add(produtoMenu);
                                count = customerReport.produtosTerca.Count();
                                break;
                            case 4:
                                customerReport.produtosQuarta.Add(produtoMenu);
                                count = customerReport.produtosQuarta.Count();
                                break;
                            case 5:
                                customerReport.produtosQuinta.Add(produtoMenu);
                                count = customerReport.produtosQuinta.Count();
                                break;
                            case 6:
                                customerReport.produtosSexta.Add(produtoMenu);
                                count = customerReport.produtosSexta.Count();
                                break;
                            case 7:
                                customerReport.produtosSabado.Add(produtoMenu);
                                count = customerReport.produtosSabado.Count();
                                break;

                        }
                        size = count > size ? count : size;
                    }
                    customerReport.maxQuantity = size;
                }
                customerByMenuReport.Add(customerReport);
            }
            List<CustomerByMenuViewModel> report = new List<CustomerByMenuViewModel>();
            foreach (var customerList in customerByMenuReport)
            {
                for (int i = 0; i < customerList.maxQuantity; i++)
                {
                    CustomerByMenuViewModel customerReport = new CustomerByMenuViewModel();
                    customerReport.IdCustomer = customerList.IdCustomer;
                    customerReport.CustomerName = customerList.CustomerName;
                    var domingo = customerList.produtosDomingo.ElementAtOrDefault(i);
                    customerReport.ProductNameDomingo = domingo != null ? domingo.Produto.Nome : "";
                    customerReport.productQuantityDomingo = domingo != null ? domingo.quantidade.ToString() : "";
                    var segunda = customerList.produtosSegunda.ElementAtOrDefault(i);
                    customerReport.ProductNameSegunda = segunda != null ? segunda.Produto.Nome : "";
                    customerReport.productQuantitySegunda = segunda != null ? segunda.quantidade.ToString() : "";
                    var terca = customerList.produtosTerca.ElementAtOrDefault(i);
                    customerReport.ProductNameTerca = terca != null ? terca.Produto.Nome : "";
                    customerReport.productQuantityTerca = terca != null ? terca.quantidade.ToString() : "";
                    var quarta = customerList.produtosQuarta.ElementAtOrDefault(i);
                    customerReport.ProductNameQuarta = quarta != null ? quarta.Produto.Nome : "";
                    customerReport.productQuantityQuarta = quarta != null ? quarta.quantidade.ToString() : "";
                    var quinta = customerList.produtosQuinta.ElementAtOrDefault(i);
                    customerReport.ProductNameQuinta = quinta != null ? quinta.Produto.Nome : "";
                    customerReport.productQuantityQuinta = quinta != null ? quinta.quantidade.ToString() : "";
                    var sexta = customerList.produtosSexta.ElementAtOrDefault(i);
                    customerReport.ProductNameSexta = sexta != null ? sexta.Produto.Nome : "";
                    customerReport.productQuantitySexta = sexta != null ? sexta.quantidade.ToString() : "";
                    var sabado = customerList.produtosSabado.ElementAtOrDefault(i);
                    customerReport.ProductNameSabado = sabado != null ? sabado.Produto.Nome : "";
                    customerReport.productQuantitySabado = sabado != null ? sabado.quantidade.ToString() : "";
                    report.Add(customerReport);
                }
            }
        
            var rd = new ReportClass();
            rd.FileName = Path.Combine(Server.MapPath("~/CrystalReports"), "CustomerByMenuDataTables.rpt");
            rd.Load();
            List<CustomerByMenuHeader> headerList = new List<CustomerByMenuHeader>();
            headerList.Add(header);
            rd.Database.Tables[0].SetDataSource(report);
            rd.Database.Tables[1].SetDataSource(headerList);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            rd.Close();
            rd.Dispose();

            return File(stream, "application/pdf", "MenuByCustomer.pdf");
        }

        public ActionResult ExportMenuByCustomer4()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();

            List<int> customerIds = allCustomer.Select(customer => customer.id).ToList();
            List<Cidade> allCidades = new List<Cidade>();
            allCidades = context.Cidade.Where(t => customerIds.Contains(t.id)).ToList();

            var customerModelList = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);
            var cidadeModelList = Mapper.Map<IEnumerable<CidadeReportViewModel>>(allCidades);
          
            var rd = new ReportClass();
            rd.FileName = Path.Combine(Server.MapPath("~/CrystalReports"), "ReportGroupingWithLink.rpt");
            rd.Load();
            rd.Database.Tables[0].SetDataSource(cidadeModelList);
            rd.Database.Tables[1].SetDataSource(customerModelList);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            rd.Close();
            rd.Dispose();

            return File(stream, "application/pdf", "MenuByCustomer.pdf");
        }

        public ActionResult ExportMenuByCustomer()
        {
            List<Customer> allCustomer = new List<Customer>();
            allCustomer = context.Customer.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomerReportViewModel>>(allCustomer);

            List<CustomerByMenuViewModel> customerByMenuReport = new List<CustomerByMenuViewModel>();

            foreach (var customer in customerModel)
            {
                List<CustomerByMenuViewModel> customerList = new List<CustomerByMenuViewModel>();
                var last = customer.CustomerMenu.Last();
                CustomerByMenuViewModel customerReport = new CustomerByMenuViewModel();
                foreach (var customerMenu in customer.CustomerMenu)
                {
                    var menu = customerMenu.Menu;

                    foreach (var produtoMenu in menu.MenuProduto)
                    {
                        var produto = produtoMenu.Produto;

                        customerReport.CustomerName = customer.CustomerName;
                        customerReport.IdCustomer = customer.id;
                        bool find = false;
                        switch (menu.dia)
                        {
                            case 1:
                                if (customerReport.ProductNameDomingo != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameDomingo = produto.Nome;
                                    customerReport.productQuantityDomingo = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameDomingo == null)
                                        {
                                            customerRow.ProductNameDomingo = produto.Nome;
                                            customerRow.productQuantityDomingo = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameDomingo = produto.Nome;
                                        customerReport.productQuantityDomingo = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 2:
                                if (customerReport.ProductNameSegunda != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameSegunda = produto.Nome;
                                    customerReport.productQuantitySegunda = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameSegunda == null)
                                        {
                                            customerRow.ProductNameSegunda = produto.Nome;
                                            customerRow.productQuantitySegunda = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameSegunda = produto.Nome;
                                        customerReport.productQuantitySegunda = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 3:
                                if (customerReport.ProductNameTerca != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameTerca = produto.Nome;
                                    customerReport.productQuantityTerca = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameTerca == null)
                                        {
                                            customerRow.ProductNameTerca = produto.Nome;
                                            customerRow.productQuantityTerca = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameTerca = produto.Nome;
                                        customerReport.productQuantityTerca = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 4:
                                if (customerReport.ProductNameQuarta != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameQuarta = produto.Nome;
                                    customerReport.productQuantityQuarta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameQuarta == null)
                                        {
                                            customerRow.ProductNameQuarta = produto.Nome;
                                            customerRow.productQuantityQuarta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameQuarta = produto.Nome;
                                        customerReport.productQuantityQuarta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 5:
                                if (customerReport.ProductNameQuinta != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameQuinta = produto.Nome;
                                    customerReport.productQuantityQuinta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameQuinta == null)
                                        {
                                            customerRow.ProductNameQuinta = produto.Nome;
                                            customerRow.productQuantityQuinta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameQuinta = produto.Nome;
                                        customerReport.productQuantityQuinta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 6:
                                if (customerReport.ProductNameSexta != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameSexta = produto.Nome;
                                    customerReport.productQuantitySexta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameSexta == null)
                                        {
                                            customerRow.ProductNameSexta = produto.Nome;
                                            customerRow.productQuantitySexta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameSexta = produto.Nome;
                                        customerReport.productQuantitySexta = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                            case 7:
                                if (customerReport.ProductNameSabado != null)
                                {
                                    customerList.Add(customerReport);
                                    customerReport = new CustomerByMenuViewModel();
                                    customerReport.CustomerName = customer.CustomerName;
                                    customerReport.IdCustomer = customer.id;
                                    customerReport.ProductNameSabado = produto.Nome;
                                    customerReport.productQuantitySabado = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                }
                                else
                                {
                                    foreach (var customerRow in customerList)
                                    {
                                        if (customerRow.ProductNameSabado == null)
                                        {
                                            customerRow.ProductNameSabado = produto.Nome;
                                            customerRow.productQuantitySabado = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                            find = true;
                                            break;
                                        }
                                    }
                                    if (!find)
                                    {
                                        customerReport.ProductNameSabado = produto.Nome;
                                        customerReport.productQuantitySabado = produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
                                    }
                                }
                                break;
                        }

                    }
                    if (customerReport.checkHasValue() && customerMenu.Equals(last))
                    {
                        customerList.Add(customerReport);
                    }

                }
                customerByMenuReport.AddRange(customerList);
            }

            ReportDocument rd = new ReportDocument();
            var combined = Path.Combine(Server.MapPath("~/CrystalReports"), "CustomerByMenu.rpt");
            rd.Load(combined);

            rd.SetDataSource(customerByMenuReport);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            rd.Close();
            rd.Dispose();

            return File(stream, "application/pdf", "MenuByCustomer.pdf");
        }

    }
}