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
            
                foreach(var customerMenu in customer.CustomerMenu)
                {
                    var menu = customerMenu.Menu;
                 

                    foreach(var produtoMenu in menu.MenuProduto)
                    {
                        var produto = produtoMenu.Produto;
                        CustomerByMenuViewModel customerReport = new CustomerByMenuViewModel();
                        customerReport.CustomerName = customer.CustomerName;
                        customerReport.IdCustomer = customer.id;
                        customerReport.IdMenu = menu.id;
                        customerReport.dia = menu.dia;
                        customerReport.ProductName = produto.Nome;
                        customerReport.IdProduct = produto.id;
                        customerByMenuReport.Add(customerReport);
                    }

                }

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