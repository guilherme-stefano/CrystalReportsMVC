using AutoMapper;
using CrystalReportMVC.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.Mapping
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<Cidade, CidadeReportViewModel>().ForMember(dest => dest.idCidade, opt => opt.MapFrom(src => src.id));
        }
    }
}