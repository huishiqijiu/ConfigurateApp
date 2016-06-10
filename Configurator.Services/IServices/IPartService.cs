using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IPartService
    {
        PartModel GetPartById(int id);
        IList<PartModel> GetAllParts(int prodID);
        int SavePart(PartModel part);
        bool UpdatePart(PartModel part);
        void DeletePart(int id);
    }
}
