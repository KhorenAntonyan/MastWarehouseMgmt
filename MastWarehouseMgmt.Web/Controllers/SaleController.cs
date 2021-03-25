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
    public class SaleController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleHistoryRepository _saleHistoryRepository;

        public SaleController(IMaterialRepository materialRepository, IProductRepository productRepository, ISaleHistoryRepository saleHistoryRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
            _saleHistoryRepository = saleHistoryRepository;
        }

        public IActionResult Sale()
        {
            var saleHistory = _saleHistoryRepository.GetAllSales().Where(p => p.IsDeleted == false).ToList();
            List<SaleHistoryViewModel> saleHistories = new List<SaleHistoryViewModel>();

            foreach (var item in saleHistory)
            {
                SaleHistoryViewModel saleHistoryViewModel = new SaleHistoryViewModel
                {
                    ProductName = item.Product.Name,
                    SaleHistoryId = item.SaleHistoryId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    CreatedDate = item.CreatedDate
                };
                saleHistories.Add(saleHistoryViewModel);
            }

            return View(saleHistories);
        }

        public IActionResult DeleteSale(int saleHistoryId)
        {
            _saleHistoryRepository.DeleteSaleHistory(saleHistoryId);
            var sale = _saleHistoryRepository.GetSaleById(saleHistoryId);
            _productRepository.UpdateProduct(sale.ProductId, sale.Quantity);

            return RedirectToAction("Index");
        }

        public IActionResult AddSale()
        {
            ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddSale(SaleHistoryViewModel addSale)
        {
            SaleHistory saleHistory = new SaleHistory
            {
                SaleHistoryId = addSale.SaleHistoryId,
                ProductId = addSale.ProductId,
                Customer = addSale.Customer,
                Quantity = addSale.Quantity,
                CreatedDate = addSale.CreatedDate
            };

            _productRepository.UpdateProduct(addSale.ProductId, -addSale.Quantity);
            _saleHistoryRepository.AddSale(saleHistory);

            return RedirectToAction("Sale");
        }
    }
}
