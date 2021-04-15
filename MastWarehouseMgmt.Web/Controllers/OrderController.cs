using AutoMapper;
using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleHistoryRepository _saleHistoryRepository;
        private readonly IOrderRepository _order;
        private readonly IMapper _mapper;


        public OrderController(IProductRepository productRepository, ISaleHistoryRepository saleHistoryRepository, IOrderRepository order, IMapper mapper)
        {
            _productRepository = productRepository;
            _saleHistoryRepository = saleHistoryRepository;
            _order = order;
            _mapper = mapper;
        }

        public IActionResult Order()
        {
            var order = _order.GetAllOrders().Where(o => o.IsDeleted == false).OrderByDescending(o => o.CreatedDate).ToList();
            var orders = _mapper.Map<List<OrderViewModel>>(order);
            return View(orders);
        }

        public IActionResult DeleteOrder(int orderId)
        {
            _order.DeleteOrder(orderId);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddSaleHistory(int orderId)
        {
            var order = _order.GetOrderById(orderId);
            var orderHistory = _mapper.Map<SaleHistory>(order);
            _saleHistoryRepository.AddSale(orderHistory);
            _productRepository.UpdateProduct(order.ProductId, -order.Quantity);
            _order.DeleteOrder(orderId);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddOrder()
        {
            ViewBag.Products = new SelectList(_productRepository.GetAllProducts(), "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(OrderViewModel addOrder)
        {
            var order = _mapper.Map<Order>(addOrder);
            _order.AddOrder(order);

            return RedirectToAction("Order");
        }
    }
}
