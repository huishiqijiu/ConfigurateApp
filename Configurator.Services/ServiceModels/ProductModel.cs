using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class ProductModel
    {
        public ProductModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Parts = product.Parts.Select(x => new PartModel(x)).ToList();
        }
        public ProductModel()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PartModel> Parts { get; set; }

        public Product GetRepoProduct()
        {
            return new Product
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
