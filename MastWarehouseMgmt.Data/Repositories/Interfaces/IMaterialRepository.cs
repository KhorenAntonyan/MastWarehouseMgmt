using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        void AddMaterial(Material material);
        List<Material> GetAllMaterial();
        public void UpdateMaterials(UpdateMaterials updateMaterials);
        public void UpdateMaterials(int? id, int quantity);
    }
}
