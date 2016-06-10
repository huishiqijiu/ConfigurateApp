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
    public class ItemService : IItemService
    {
        IItemRepository _itemRepo;
        public ItemService(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public void DeleteItem(int id)
        {
            _itemRepo.DeleteItem(id);
        }

        public IList<ItemModel> GetAllItems(int itemTypeID)
        {
            return _itemRepo.GetAllItems(itemTypeID).Select(x => new ItemModel(x)).ToList();
        }

        public ItemModel GetItemById(int id)
        {
            Item i = _itemRepo.GetItemById(id);
            ItemModel im = new ItemModel();
            im.Id = i.Id;
            im.Name = i.Name;
            im.Price = i.Price;
            im.DeliveryTime = i.DeliveryTime;
            im.Code = i.Code;
            return im;
        }

        public IList<ItemModel> GetItems()
        {
            return _itemRepo.GetItems().Select(x => new ItemModel(x)).ToList();
        }

        public IList<ItemModel> GetItemsByCode(string code)
        {
            return _itemRepo.GetItemsByCode(code).Select(x => new ItemModel(x)).ToList();
        }

        public int SaveItem(ItemModel item)
        {
            return _itemRepo.SaveItem(item.GetRepoItem());
        }

        public bool UpdateItem(ItemModel item)
        {
            throw new NotImplementedException();
        }
    }
}
