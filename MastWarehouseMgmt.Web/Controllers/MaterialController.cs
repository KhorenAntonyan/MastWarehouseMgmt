using AutoMapper;
using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.Infrastructure.Mappers;
using MastWarehouseMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMaterialHistoryRepository _materialHistoryRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IProductRepository productRepository, IMaterialHistoryRepository materialHistoryRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _materialHistoryRepository = materialHistoryRepository;
            _mapper = mapper;
        }

        public IActionResult Material()
        {
            var materialHistory = _materialHistoryRepository.GetAllMaterials().Where(p => p.IsDeleted == false).ToList();
            var materialHistories = _mapper.Map<List<MaterialHistory>, List<MaterialHistoryViewModel>>(materialHistory);    

            return View(materialHistories);
        }

        public IActionResult DeleteMaterial(int materialHistoryId)
        {
            _materialHistoryRepository.DeleteMaterialHistory(materialHistoryId);
            var material = _materialHistoryRepository.GetMaterialById(materialHistoryId);
            _materialRepository.UpdateMaterials(material.MaterialId, -material.Quantity);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddMaterial()
        {
            ViewBag.Materials = new SelectList(_materialRepository.GetAllMaterial(), "MaterialId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddMaterial(MaterialHistoryViewModel addMaterial)
        {
            var materialHistory = _mapper.Map<MaterialHistory>(addMaterial);
            _materialRepository.UpdateMaterials(addMaterial.MaterialId, addMaterial.Quantity);
            _materialHistoryRepository.AddMaterial(materialHistory);

            return RedirectToAction("Material");
        }
    }
}
