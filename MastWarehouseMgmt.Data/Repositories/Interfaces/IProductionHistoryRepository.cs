using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories.Interfaces
{
    public interface IProductionHistoryRepository
    {
        void AddProduction(ProductionHistory production);
        List<ProductionHistory> GetAllProductions();
        void DeleteProduction(int productionHistoryId);
        ProductionHistory GetProductionById(int id);
    }
}
