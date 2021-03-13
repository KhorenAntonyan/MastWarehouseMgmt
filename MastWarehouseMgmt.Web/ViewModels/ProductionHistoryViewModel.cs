using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.ViewModels
{
    public class ProductionHistoryViewModel
    {

        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cement { get; set; }
        public double CR400 { get; set; }
        public double Sand { get; set; }
        public double Gypsum { get; set; }
        public double Lithium { get; set; }
        public double Acronal { get; set; }
        public double Soda { get; set; }
        public double Glue { get; set; }
        public double C3 { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
