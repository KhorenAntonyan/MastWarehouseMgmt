using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public int GetQuantitySum()
        {
            return _context.Products.Sum(item => item.Quantity);
        }

        public void UpdateProduct(int id, int quantity)
        {
            var Id = _context.Products.First(a => a.ProductId == id);
            Id.Quantity += quantity;
            _context.SaveChanges();
        }
    }
}
