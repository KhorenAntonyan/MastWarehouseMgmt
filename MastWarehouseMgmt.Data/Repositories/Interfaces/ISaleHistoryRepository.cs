using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories.Interfaces
{
    public interface ISaleHistoryRepository
    {
        void AddSale(SaleHistory sale);
        List<SaleHistory> GetAllSales();
        public void DeleteSaleHistory(int id);
        public SaleHistory GetSaleById(int id);
    }
}
