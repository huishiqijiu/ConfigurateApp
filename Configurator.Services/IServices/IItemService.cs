using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IItemService
    {
        ItemModel GetItemById(int id);
        IList<ItemModel> GetAllItems(int itemTypeID);
        IList<ItemModel> GetItems();
        int SaveItem(ItemModel item);
        bool UpdateItem(ItemModel item);
        void DeleteItem(int id);
        IList<ItemModel> GetItemsByCode(string code);
    }
}
