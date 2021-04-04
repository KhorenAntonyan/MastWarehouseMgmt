using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Web.Infrastructure.Mappers.Base;
using MastWarehouseMgmt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Infrastructure.Mappers
{
    public class MaterialMapperConfiguration : MapperConfigurationBase
    {
        public MaterialMapperConfiguration()
        {
            CreateMap<MaterialHistory, MaterialHistoryViewModel>();
            CreateMap<MaterialHistoryViewModel, MaterialHistory>();
        }
    }
}
