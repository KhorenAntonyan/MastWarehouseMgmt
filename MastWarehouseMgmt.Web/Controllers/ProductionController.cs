using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductionController(IMaterialRepository materialRepository, IProductRepository productRepository, IProductionHistoryRepository productionHistoryRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _productionHistoryRepository = productionHistoryRepository;
            _mapper = mapper;
        }
        public IActionResult Production()
        {
            var productionHistory = _productionHistoryRepository.GetAllProductions().Where(p => p.IsDeleted == false).ToList();

            var productionHistoryViewModel = _mapper.Map<List<ProductionHistory>, List<ProductionHistoryViewModel>>(productionHistory);

            return View(productionHistoryViewModel);
        }

        public IActionResult DeleteProduction(int productionHistoryId)
        {
            _productionHistoryRepository.DeleteProduction(productionHistoryId);
            var production = _productionHistoryRepository.GetProductionById(productionHistoryId);
            _productRepository.UpdateProduct(production.ProductId, -production.Quantity);
            var updateMaterial = _mapper.Map<UpdateMaterials>(production);
            _materialRepository.UpdateMaterials(updateMaterial);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddProduction()
        {
            ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduction(ProductionHistoryViewModel addProduction)
        {
            var production = _mapper.Map<ProductionHistory>(addProduction);
            var updateMateria = _mapper.Map<UpdateMaterials>(addProduction);
            _productRepository.UpdateProduct(addProduction.ProductId, addProduction.Quantity);
            _materialRepository.UpdateMaterials(updateMateria);
            _productionHistoryRepository.AddProduction(production);

            return RedirectToAction("Production");
        }
    }
}
