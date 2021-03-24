using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories
{
    public class SaleHistoryRepository : ISaleHistoryRepository
    {
        private readonly AppDbContext _context;

        public SaleHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddSale(SaleHistory sale)
        {
            _context.SaleHistories.Add(sale);
            _context.SaveChanges();
        }

        public void DeleteSaleHistory(int id)
        {
            var sale = _context.SaleHistories.First(a => a.SaleHistoryId == id);
            sale.IsDeleted = true;
            _context.SaveChanges();
        }

        public SaleHistory GetSaleById(int id)
        {
            return _context.SaleHistories.First(s => s.SaleHistoryId == id);
        }

        public List<SaleHistory> GetAllSales()
        {
            return _context.SaleHistories.Include(s => s.Product).ToList();
        }
    }
}
