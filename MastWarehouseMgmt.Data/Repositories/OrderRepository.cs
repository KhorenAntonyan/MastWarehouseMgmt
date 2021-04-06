using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.First(o => o.OrderId == id);
            order.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.Product).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.First(o => o.OrderId == id);
        }
    }
}
