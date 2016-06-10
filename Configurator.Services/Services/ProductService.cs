using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using Configurator.DataLayer.IRepository;
using Configurator.DataLayer;

namespace Configurator.Services.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;
        public ProductService (IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public void DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
        }

        public IList<ProductModel> GetAllProducts()
        {
            return _productRepo.GetAllProducts().Select(x=> new ProductModel (x)).ToList();
        }

        public ProductModel GetProductById(int id)
        {
            Product prod = _productRepo.GetProductById(id);
            ProductModel p = new ProductModel();
            p.Id = prod.Id;
            p.Name = prod.Name;
            return p;
        }

        public int SaveProduct(ProductModel product)
        {
            int id = _productRepo.SaveProduct(product.GetRepoProduct());
            return id;
        }

        public bool UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
