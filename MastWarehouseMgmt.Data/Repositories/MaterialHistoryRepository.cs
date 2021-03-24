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
    public class MaterialHistoryRepository : IMaterialHistoryRepository
    {
        private readonly AppDbContext _context;

        public MaterialHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddMaterial(MaterialHistory rawMaterial)
        {
            _context.MaterialHistories.Add(rawMaterial);
            _context.SaveChanges();
        }

        public void DeleteMaterialHistory(int id)
        {
            var material = _context.MaterialHistories.First(a => a.MaterialHistoryId == id);
            material.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<MaterialHistory> GetAllMaterials()
        {
            return _context.MaterialHistories.Include(p => p.Material).ToList();
        }

        public MaterialHistory GetMaterialById(int id)
        {
            return _context.MaterialHistories.First(m => m.MaterialHistoryId == id);
        }
    }
}
