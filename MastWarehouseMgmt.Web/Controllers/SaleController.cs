using AutoMapper;
using ClosedXML.Excel;
using MastWarehouseMgmt.Data.Entities;
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
    public class SaleController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleHistoryRepository _saleHistoryRepository;
        private readonly IMapper _mapper;

        public SaleController(IMaterialRepository materialRepository, IProductRepository productRepository, ISaleHistoryRepository saleHistoryRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _saleHistoryRepository = saleHistoryRepository;
            _mapper = mapper;
        }

        public IActionResult Sale()
        {
            var saleHistory = _saleHistoryRepository.GetAllSales().Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedDate).ToList();
            var saleHistories = _mapper.Map<List<SaleHistory>, List<SaleHistoryViewModel>>(saleHistory);

            return View(saleHistories);
        }

        public IActionResult DeleteSale(int saleHistoryId)
        {
            _saleHistoryRepository.DeleteSaleHistory(saleHistoryId);
            var sale = _saleHistoryRepository.GetSaleById(saleHistoryId);
            _productRepository.UpdateProduct(sale.ProductId, sale.Quantity);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddSale()
        {
            ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddSale(SaleHistoryViewModel addSale)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
                return View(addSale);
            }

            var saleHistory = _mapper.Map<SaleHistory>(addSale);

            _productRepository.UpdateProduct(addSale.ProductId, -addSale.Quantity);
            _saleHistoryRepository.AddSale(saleHistory);

            return RedirectToAction("Sale");
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var saleHistory = _saleHistoryRepository.GetAllSales().Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedDate).ToList();
                var worksheet = workbook.Worksheets.Add("SaleHistory");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "CreatedDate";
                worksheet.Cell(currentRow, 2).Value = "Customer";
                worksheet.Cell(currentRow, 3).Value = "Product";
                worksheet.Cell(currentRow, 4).Value = "Quantity";
                foreach (var data in saleHistory)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = data.CreatedDate;
                    worksheet.Cell(currentRow, 2).Value = data.Customer;
                    worksheet.Cell(currentRow, 3).Value = data.Product.Name;
                    worksheet.Cell(currentRow, 4).Value = data.Quantity;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "SaleHistory.xlsx");
                }
            }
        }
    }
}
