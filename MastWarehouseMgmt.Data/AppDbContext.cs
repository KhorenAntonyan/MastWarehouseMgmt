using MastWarehouseMgmt.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductionHistory> ProductionHistories { get; set; }
        public DbSet<MaterialHistory> MaterialHistories { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
