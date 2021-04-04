using AutoMapper;
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
            var saleHistory = _saleHistoryRepository.GetAllSales().Where(p => p.IsDeleted == false).ToList();
            var saleHistories = _mapper.Map<List<SaleHistory>, List<SaleHistoryViewModel>>(saleHistory);

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
            var saleHistory = _mapper.Map<SaleHistory>(addSale);

            _productRepository.UpdateProduct(addSale.ProductId, -addSale.Quantity);
            _saleHistoryRepository.AddSale(saleHistory);

            return RedirectToAction("Sale");
        }
    }
}
