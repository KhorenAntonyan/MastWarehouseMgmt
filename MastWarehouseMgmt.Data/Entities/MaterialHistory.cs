using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Entities
{
    public class MaterialHistory : IEntityBase
    {
        public int MaterialHistoryId { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
