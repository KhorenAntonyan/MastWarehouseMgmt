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
    public class HomeController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductionHistoryRepository _productionHistoryRepository;
        private readonly IMaterialHistoryRepository _materialHistoryRepository;

        public HomeController(IMaterialRepository materialRepository, IProductRepository productRepository, IProductionHistoryRepository productionHistoryRepository, IMaterialHistoryRepository materialHistoryRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _productionHistoryRepository = productionHistoryRepository;
            _materialHistoryRepository = materialHistoryRepository;
        }

        public IActionResult Index()
        {
            var materials = _materialRepository.GetAllMaterial();
            var products = _productRepository.GetAllProducts().Where(p => p.IsDeleted == false).ToList();
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

        public IActionResult Material()
        {
            var materialHistory = _materialHistoryRepository.GetAllMaterials().Where(p => p.IsDeleted == false).ToList();
            List<MaterialHistoryViewModel> materialHistories = new List<MaterialHistoryViewModel>();

            foreach (var item in materialHistory)
            {
                MaterialHistoryViewModel MaterialHistoryViewModel = new MaterialHistoryViewModel
                {
                    MaterialName = item.Material.Name,
                    MaterialHistoryId = item.MaterialHistoryId,
                    MaterialId = item.MaterialId,
                    Quantity = item.Quantity,
                    CreatedDate = item.CreatedDate
                };
                materialHistories.Add(MaterialHistoryViewModel);
            }

            return View(materialHistories);
        }

        public IActionResult DeleteMaterial(int materialHistoryId)
        {
            _materialHistoryRepository.DeleteMaterialHistory(materialHistoryId);
            var material = _materialHistoryRepository.GetMaterialById(materialHistoryId);
            _materialRepository.UpdateMaterials(material.MaterialId, -material.Quantity);

            return RedirectToAction("Index");
        }

        public IActionResult AddMaterial()
        {
            ViewBag.Products = new SelectList(_materialRepository.GetAllMaterial(), "MaterialId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMaterial(MaterialHistoryViewModel addMaterial)
        {
            MaterialHistory materialHistory = new MaterialHistory
            {
                MaterialHistoryId = addMaterial.MaterialHistoryId,
                MaterialId = addMaterial.MaterialId,
                Quantity = addMaterial.Quantity,
                CreatedDate = addMaterial.CreatedDate
            };

            _materialRepository.UpdateMaterials(addMaterial.MaterialId, addMaterial.Quantity);
            _materialHistoryRepository.AddMaterial(materialHistory);

            return RedirectToAction("Material");
        }
    }
}
