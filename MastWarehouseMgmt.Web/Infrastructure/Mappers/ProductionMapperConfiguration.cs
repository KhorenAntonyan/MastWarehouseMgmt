using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Models;
using MastWarehouseMgmt.Web.Infrastructure.Mappers.Base;
using MastWarehouseMgmt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Infrastructure.Mappers
{
    public class ProductionMapperConfiguration : MapperConfigurationBase
    {
        public ProductionMapperConfiguration()
        {
            CreateMap<ProductionHistory, ProductionHistoryViewModel>();
            CreateMap<ProductionHistoryViewModel, ProductionHistory>();
            CreateMap<UpdateMaterials, ProductionHistory>();
            CreateMap<ProductionHistory, UpdateMaterials>();
            CreateMap<ProductionHistoryViewModel, UpdateMaterials>()
                .ForMember("Cement",
                opt => opt.MapFrom(src => -src.Cement))
                .ForMember("CR400",
                opt => opt.MapFrom(src => -src.CR400));
        }
    }
}
