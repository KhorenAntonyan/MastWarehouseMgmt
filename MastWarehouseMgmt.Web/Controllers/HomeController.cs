﻿using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(IMaterialRepository materialRepository, IProductRepository productRepository)
        {
            _materialRepository = materialRepository;
            _productRepository = productRepository;
        }



        public IActionResult Index()
        {
            var materials = _materialRepository.GetAllMaterial();
            var products = _productRepository.GetAllProducts();
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
    }
}
