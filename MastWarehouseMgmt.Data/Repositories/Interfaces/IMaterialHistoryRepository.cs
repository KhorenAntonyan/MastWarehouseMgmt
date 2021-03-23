using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories.Interfaces
{
    public interface IMaterialHistoryRepository
    {
        void AddMaterial(MaterialHistory rawMaterial);
        List<MaterialHistory> GetAllMaterials();
        void DeleteMaterialHistory(int id);
        public MaterialHistory GetMaterialById(int id);

    }
}
