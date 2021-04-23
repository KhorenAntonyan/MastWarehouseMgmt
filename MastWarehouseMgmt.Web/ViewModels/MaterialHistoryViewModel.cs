using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.ViewModels
{
    public class MaterialHistoryViewModel
    {
        public int MaterialHistoryId { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int? MaterialId { get; set; }
        public string MaterialName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
