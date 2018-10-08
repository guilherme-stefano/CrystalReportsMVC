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
                            case 1 :
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
                                        if(customerRow.ProductNameDomingo == null)
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
                                if (customerReport.ProductNameSexta!= null)
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
                                            customerRow.productQuantitySabado= produtoMenu.quantidade != 0 ? produtoMenu.quantidade.ToString() : "";
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
                    if(customerReport.checkHasValue() && customerMenu.Equals(last)) {
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