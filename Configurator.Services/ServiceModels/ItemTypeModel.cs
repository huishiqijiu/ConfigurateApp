using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class ItemTypeModel
    {
        public ItemTypeModel(ItemType itemType)
        {
            Id = itemType.Id;
            Name = itemType.Name;
            PartId = itemType.PartId;
            Items = itemType.Items.Select(x => new ItemModel(x)).ToList();
        }
        public ItemTypeModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PartId { get; set; }
        public virtual ICollection<ItemModel> Items { get; set; }

        public ItemType GetRepoItemType()
        {
            return new ItemType
            {
                Id = Id,
                Name = Name,
                PartId = PartId
            };
        }
    }
}
