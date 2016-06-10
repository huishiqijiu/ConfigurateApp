using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{

    public class ProductRepository : IProductRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();

        public void DeleteProduct(int id)
        {
            Product p = db.Products.FirstOrDefault(x => x.Id == id);
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public IList<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }

        public int SaveProduct(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
            return product.Id;
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
