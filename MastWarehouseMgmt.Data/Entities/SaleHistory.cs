using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Entities
{
    public class SaleHistory : IEntityBase
    {
        public int SaleHistoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
