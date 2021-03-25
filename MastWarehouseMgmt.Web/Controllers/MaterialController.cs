﻿using MastWarehouseMgmt.Data.Entities;
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
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMaterialHistoryRepository _materialHistoryRepository;

        public MaterialController(IMaterialRepository materialRepository, IProductRepository productRepository, IMaterialHistoryRepository materialHistoryRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _materialHistoryRepository = materialHistoryRepository;
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
            ViewBag.Materials = new SelectList(_materialRepository.GetAllMaterial(), "MaterialId", "Name");
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