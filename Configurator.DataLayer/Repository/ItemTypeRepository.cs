using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        public void DeleteType(int id)
        {
            ItemType type = db.ItemTypes.FirstOrDefault(x => x.Id == id);
            db.ItemTypes.Remove(type);
            db.SaveChanges();
        }

        public IList<ItemType> GetAllItemTypes(int partID)
        {
            return db.ItemTypes.Where(x => x.PartId == partID).ToList();
        }

        public ItemType GetItemTypeById(int id)
        {
            return db.ItemTypes.FirstOrDefault(x => x.Id == id);
        }

        public int SaveItemType(ItemType type)
        {
            db.ItemTypes.Add(type);
            db.SaveChanges();
            return type.Id;
        }

        public bool UpdateItemType(ItemType type)
        {
            throw new NotImplementedException();
        }
    }
}
