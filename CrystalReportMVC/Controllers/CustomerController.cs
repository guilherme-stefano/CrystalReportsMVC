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
            var customerList = context.Customers.ToList();
            return View(customerList);
        }

        public ActionResult ExportCustomers()
        {
            List<Customers> allCustomer = new List<Customers>();
            allCustomer = context.Customers.ToList();
            var customerModel = Mapper.Map<IEnumerable<CustomersReportViewModel>>(allCustomer);
            ReportDocument rd = new ReportDocument();
            var combined = Path.Combine(Server.MapPath("~/CrystalReports"), "Customer.rpt");
            rd.Load(combined);

            rd.SetDataSource(customerModel);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");
        }




    }
}