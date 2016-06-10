using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class ItemModel
    {
        public ItemModel(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Code = item.Code;
            DeliveryTime = item.DeliveryTime;
            ItemTypeId = item.ItemTypeId;
        }
        public ItemModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int ItemTypeId { get; set; }

        public Item GetRepoItem()
        {
            return new Item
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Code = Code,
                DeliveryTime = DeliveryTime,
                ItemTypeId = ItemTypeId
            };
        }
    }
}
