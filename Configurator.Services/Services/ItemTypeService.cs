using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using Configurator.DataLayer.IRepository;

namespace Configurator.Services.Services
{
    
    public class ItemTypeService : IItemTypeService
    {
        IItemTypeRepository _typeRepo;
        public ItemTypeService(IItemTypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }
        public void DeleteType(int id)
        {
            _typeRepo.DeleteType(id);
        }

        public IList<ItemTypeModel> GetAllItemTypes(int partID)
        {
            return _typeRepo.GetAllItemTypes(partID).Select(x => new ItemTypeModel(x)).ToList();
        }

        public ItemTypeModel GetItemTypeById(int id)
        {
            var type = _typeRepo.GetItemTypeById(id);
            ItemTypeModel itm = new ItemTypeModel();
            itm.Id = type.Id;
            itm.Name = type.Name;
            itm.PartId = type.PartId;
            return itm;
        }

        public int SaveItemType(ItemTypeModel type)
        {
            return _typeRepo.SaveItemType(type.GetRepoItemType());
        }

        public bool UpdateItemType(ItemTypeModel type)
        {
            throw new NotImplementedException();
        }
    }
}
