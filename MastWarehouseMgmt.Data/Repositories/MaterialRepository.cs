using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Models;
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

        public void UpdateMaterials(UpdateMaterials updateMaterials)
        {
            var cement = _context.Materials.First(m => m.Name == "Цемент");
            cement.Quantity += updateMaterials.Cement;
            var cr400 = _context.Materials.First(m => m.Name == "CR400");
            cr400.Quantity += updateMaterials.CR400;
            _context.SaveChanges();
        }

        public void UpdateMaterials(int id, int quantity)
        {
            var Id = _context.Materials.First(a => a.MaterialId == id);
            Id.Quantity += quantity;
            _context.SaveChanges();
        }
    }
}
