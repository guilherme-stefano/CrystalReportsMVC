﻿using AutoMapper;
using CrystalReportMVC.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportMVC.Mapping
{
    public class MenuProdutoProfile : Profile
    {
        public MenuProdutoProfile()
        {
            CreateMap<MenuProdutoReportViewModel, MenuProduto>().ReverseMap();
        }
    }
}