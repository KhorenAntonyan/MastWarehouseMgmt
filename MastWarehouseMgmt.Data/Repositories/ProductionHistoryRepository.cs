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
    public class ProductionHistoryRepository : IProductionHistoryRepository
    {
        private readonly AppDbContext _context;
        
        public ProductionHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddProduction(ProductionHistory production)
        {
            _context.ProductionHistories.Add(production);
            _context.SaveChanges();
        }

        public List<ProductionHistory> GetAllProductions()
        {
            return _context.ProductionHistories.Include(p=> p.Product).ToList();
        }

        public void DeleteProduction(int id)
        {
            var production = _context.ProductionHistories.First(a => a.ProductionHistoryId == id);
            production.IsDeleted = true;
            _context.SaveChanges();
        }

        public ProductionHistory GetProductionById(int id)
        {
            return _context.ProductionHistories.First(p => p.ProductionHistoryId == id);
        }
    }
}
