using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductionHistoryRepository _productionHistoryRepository;

        public HomeController(IMaterialRepository materialRepository, IProductRepository productRepository, IProductionHistoryRepository productionHistoryRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _productionHistoryRepository = productionHistoryRepository;
        }

        public IActionResult Index()
        {
            var materials = _materialRepository.GetAllMaterial();
            var products = _productRepository.GetAllProducts();
            var quantitySum = _productRepository.GetQuantitySum();
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Materials = materials,
                Products = products,
                WarehouseProgress = quantitySum / 10,
                FreeSpace = 1000 - quantitySum
            };
            return View(indexViewModel);
        }

        public IActionResult Production()
        {
            var productionHistory = _productionHistoryRepository.GetAllProductions();
            List<ProductionHistoryViewModel> productionHistoryViewModel = new List<ProductionHistoryViewModel>();

            foreach (var item in productionHistory)
            {
                ProductionHistoryViewModel ProductionHistoryViewModel = new ProductionHistoryViewModel
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    Cement = item.Cement,
                    CR400 = item.CR400,
                    Sand = item.Sand,
                    Gypsum = item.Gypsum,
                    Lithium = item.Lithium,
                    Acronal = item.Acronal,
                    Soda = item.Soda,
                    Glue = item.Glue,
                    CreatedDate = item.CreatedDate,
                    C3 = item.C3
                };
                productionHistoryViewModel.Add(ProductionHistoryViewModel);
            }

            return View(productionHistoryViewModel);
        }

        public IActionResult AddProduction()
        {
            ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduction(ProductionHistoryViewModel addProduction)
        {
            ProductionHistory production = new ProductionHistory()
            {
                ProductId = addProduction.ProductId,
                Quantity = addProduction.Quantity,
                Cement = addProduction.Cement,
                CR400 = addProduction.CR400,
                Sand = addProduction.Sand,
                Gypsum = addProduction.Gypsum,
                Lithium = addProduction.Lithium,
                Acronal = addProduction.Acronal,
                Soda = addProduction.Soda,
                Glue = addProduction.Glue,
                CreatedDate = addProduction.CreatedDate,
                C3 = addProduction.C3
            };

            _productionHistoryRepository.AddProduction(production);
            return RedirectToAction("Production");
        }
    }
}
