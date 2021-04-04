using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Web.Infrastructure.Mappers.Base;
using MastWarehouseMgmt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Infrastructure.Mappers
{
    public class SaleMapperConfiguration : MapperConfigurationBase
    {
        public SaleMapperConfiguration()
        {
            CreateMap<SaleHistory, SaleHistoryViewModel>();
            CreateMap<SaleHistoryViewModel, SaleHistory>();
        }
    }
}
