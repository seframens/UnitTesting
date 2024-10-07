using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Shop
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProductById(int id);
    }

}
