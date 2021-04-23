using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.ViewModels
{
    public class ProductionHistoryViewModel
    {
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Не указано")]
        public int? ProductId { get; set; }
        public int ProductionHistoryId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Cement { get; set; }
        [Required]
        public double CR400 { get; set; }
        [Required]
        public double Sand { get; set; }
        public double Gypsum { get; set; }
        public double Lithium { get; set; }
        public double Acronal { get; set; }
        public double Soda { get; set; }
        public double Glue { get; set; }
        public double C3 { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
