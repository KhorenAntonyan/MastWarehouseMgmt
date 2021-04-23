using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public string Customer { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
