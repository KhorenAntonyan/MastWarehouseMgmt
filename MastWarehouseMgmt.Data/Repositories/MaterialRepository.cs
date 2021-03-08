using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;

        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public List<Material> GetAllMaterial()
        {
            return _context.Materials.ToList();
        }
    }
}
