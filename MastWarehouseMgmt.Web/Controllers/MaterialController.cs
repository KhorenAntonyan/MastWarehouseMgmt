using AutoMapper;
using ClosedXML.Excel;
using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.Infrastructure.Mappers;
using MastWarehouseMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Controllers
{
    [Authorize]
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
            var materialHistory = _materialHistoryRepository.GetAllMaterials().Where(m => m.IsDeleted == false).OrderByDescending(m => m.CreatedDate).ToList();
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
            if (!ModelState.IsValid)
            {
                ViewBag.Materials = new SelectList(_materialRepository.GetAllMaterial(), "MaterialId", "Name");
                return View(addMaterial);
            }

            var materialHistory = _mapper.Map<MaterialHistory>(addMaterial);
            _materialRepository.UpdateMaterials(addMaterial.MaterialId, addMaterial.Quantity);
            _materialHistoryRepository.AddMaterial(materialHistory);

            return RedirectToAction("Material");
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var materialHistory = _materialHistoryRepository.GetAllMaterials().Where(m => m.IsDeleted == false).OrderByDescending(m => m.CreatedDate).ToList();
                var worksheet = workbook.Worksheets.Add("MaterialHistory");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "CreatedDate";
                worksheet.Cell(currentRow, 2).Value = "Material";
                worksheet.Cell(currentRow, 3).Value = "Quantity";
                foreach (var data in materialHistory)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = data.CreatedDate;
                    worksheet.Cell(currentRow, 2).Value = data.Material.Name;
                    worksheet.Cell(currentRow, 3).Value = data.Quantity;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "MaterialHistory.xlsx");
                }
            }
        }

    }
}
