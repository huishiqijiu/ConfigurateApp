using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        IList<Product> GetAllProducts();
        int SaveProduct(Product product);
        bool UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
