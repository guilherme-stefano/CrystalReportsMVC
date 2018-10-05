using AutoMapper;
using CrystalReportMVC.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.Mapping
{
    public class CustomerMenuProfile : Profile
    {
        public CustomerMenuProfile()
        {
            CreateMap<CustomerMenuReportViewModel, CustomerMenu>().ReverseMap();
        }
    }
}