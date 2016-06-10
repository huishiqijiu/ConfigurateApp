using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class ItemRepository : IItemRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        public void DeleteItem(int id)
        {
            Item i = db.Items.FirstOrDefault(x=>x.Id==id);
            db.Items.Remove(i);
            db.SaveChanges();
        }

        

        public IList<Item> GetAllItems(int itemTypeID)
        {
            return db.Items.Where(x => x.ItemTypeId == itemTypeID).ToList();
        }

        public IList<Item> GetItemsByCode(string code)
        {
            return db.Items.Where(x => x.Code.Contains(code)).ToList();
        }

        

        public Item GetItemById(int id)
        {
            return db.Items.FirstOrDefault(x => x.Id == id);
        }

        public IList<Item> GetItems()
        {
            return db.Items.ToList();
        }

        public int SaveItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return item.Id;
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
