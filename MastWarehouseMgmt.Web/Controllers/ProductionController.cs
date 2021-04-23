using AutoMapper;
using ClosedXML.Excel;
using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Models;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
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
            var productionHistory = _productionHistoryRepository.GetAllProductions().Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedDate).ToList();

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
            if (!ModelState.IsValid)
            {
                ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
                return View(addProduction);
            }

            var production = _mapper.Map<ProductionHistory>(addProduction);
            var updateMateria = _mapper.Map<UpdateMaterials>(addProduction);
            _productRepository.UpdateProduct(addProduction.ProductId, addProduction.Quantity);
            _materialRepository.UpdateMaterials(updateMateria);
            _productionHistoryRepository.AddProduction(production);

            return RedirectToAction("Production");
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var productionHistory = _productionHistoryRepository.GetAllProductions().Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedDate).ToList();
                var worksheet = workbook.Worksheets.Add("ProductionHistory");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "CreatedDate";
                worksheet.Cell(currentRow, 2).Value = "Product";
                worksheet.Cell(currentRow, 3).Value = "Quantity";
                worksheet.Cell(currentRow, 4).Value = "Cement";
                worksheet.Cell(currentRow, 5).Value = "Sand";
                worksheet.Cell(currentRow, 6).Value = "CR400";
                worksheet.Cell(currentRow, 7).Value = "Gypsum";
                worksheet.Cell(currentRow, 8).Value = "Lithium";
                worksheet.Cell(currentRow, 9).Value = "Acronal";
                worksheet.Cell(currentRow, 10).Value = "Soda";
                worksheet.Cell(currentRow, 11).Value = "Glue";
                worksheet.Cell(currentRow, 12).Value = "C3";
                foreach (var data in productionHistory)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = data.CreatedDate;
                    worksheet.Cell(currentRow, 2).Value = data.Product.Name;
                    worksheet.Cell(currentRow, 3).Value = data.Quantity;
                    worksheet.Cell(currentRow, 4).Value = data.Cement;
                    worksheet.Cell(currentRow, 5).Value = data.Sand;
                    worksheet.Cell(currentRow, 6).Value = data.CR400;
                    worksheet.Cell(currentRow, 7).Value = data.Gypsum;
                    worksheet.Cell(currentRow, 8).Value = data.Lithium;
                    worksheet.Cell(currentRow, 9).Value = data.Acronal;
                    worksheet.Cell(currentRow, 10).Value = data.Soda;
                    worksheet.Cell(currentRow, 11).Value = data.Glue;
                    worksheet.Cell(currentRow, 12).Value = data.C3;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ProductionHistory.xlsx");
                }
            }
        }
    }
}
