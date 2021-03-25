using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Models;
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
    public class ProductionController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductionHistoryRepository _productionHistoryRepository;

        public ProductionController(IMaterialRepository materialRepository, IProductRepository productRepository, IProductionHistoryRepository productionHistoryRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _productionHistoryRepository = productionHistoryRepository;
        }
        public IActionResult Production()
        {
            var productionHistory = _productionHistoryRepository.GetAllProductions().Where(p => p.IsDeleted == false).ToList();
            List<ProductionHistoryViewModel> productionHistoryViewModel = new List<ProductionHistoryViewModel>();

            foreach (var item in productionHistory)
            {
                ProductionHistoryViewModel ProductionHistoryViewModel = new ProductionHistoryViewModel
                {
                    ProductName = item.Product.Name,
                    ProductId = item.Product.ProductId,
                    ProductHistoryId = item.ProductionHistoryId,
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

        public IActionResult DeleteProduction(int productionHistoryId)
        {
            _productionHistoryRepository.DeleteProduction(productionHistoryId);
            var production = _productionHistoryRepository.GetProductionById(productionHistoryId);
            _productRepository.UpdateProduct(production.ProductId, -production.Quantity);

            UpdateMaterials updateMaterial = new UpdateMaterials()
            {
                Cement = production.Cement,
                CR400 = production.CR400,
                Sand = production.Sand,
                Gypsum = production.Gypsum,
                Lithium = production.Lithium,
                Acronal = production.Acronal,
                Soda = production.Soda,
                Glue = production.Glue,
                C3 = production.C3
            };
            _materialRepository.UpdateMaterials(updateMaterial);

            return RedirectToAction("Index");
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

            UpdateMaterials updateMaterial = new UpdateMaterials()
            {
                Cement = -addProduction.Cement,
                CR400 = -addProduction.CR400,
                Sand = -addProduction.Sand,
                Gypsum = -addProduction.Gypsum,
                Lithium = -addProduction.Lithium,
                Acronal = -addProduction.Acronal,
                Soda = -addProduction.Soda,
                Glue = -addProduction.Glue,
                C3 = -addProduction.C3
            };

            _productRepository.UpdateProduct(addProduction.ProductId, addProduction.Quantity);
            _materialRepository.UpdateMaterials(updateMaterial);
            _productionHistoryRepository.AddProduction(production);
            return RedirectToAction("Production");
        }
    }
}
