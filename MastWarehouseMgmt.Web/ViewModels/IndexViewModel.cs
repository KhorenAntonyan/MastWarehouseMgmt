using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.ViewModels
{
    public class IndexViewModel
    {
        public List<Material> Materials { get; set; }
        public List<Product> Products { get; set; }
        public int WarehouseProgress { get; set; }
        public int FreeSpace { get; set; }
    }
}
