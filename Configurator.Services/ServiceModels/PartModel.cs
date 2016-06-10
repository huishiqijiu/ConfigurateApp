using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class PartModel
    {
        public PartModel(Part part)
        {
            Id = part.Id;
            Name = part.Name;
            ProductId = part.ProductId;
            ItemTypes = part.ItemTypes.Select(x => new ItemTypeModel(x)).ToList();
        }
        public PartModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<ItemTypeModel> ItemTypes { get; set; }
        public Part GetRepoPart()
        {
            return new Part
            {
                Id = Id,
                Name = Name,
                ProductId = ProductId 
            };
        }
    }
}
