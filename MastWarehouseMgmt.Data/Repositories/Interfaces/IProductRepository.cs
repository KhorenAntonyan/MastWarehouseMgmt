using MastWarehouseMgmt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
    }
}
