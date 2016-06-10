using Configurator.DataLayer.IRepository;
using Configurator.Services.IServices;
using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.Services
{
    public class FinalDesignService : IFinalDesignService
    {
        IFinalDesignRepository _finalDesignRepository;
        public FinalDesignService(IFinalDesignRepository finalDesignRepository)
        {
            _finalDesignRepository = finalDesignRepository;
        }
        public byte[] GetImage()
        {
            throw new NotImplementedException();
        }

        public string GetImagePath(string code)
        {
            return _finalDesignRepository.GetImgPath(code);
        }

        public bool HasImg(string code)
        {
            return _finalDesignRepository.HasImg(code);
        }

        public void SaveFinalDesign(FinalDesignModel fd)
        {
            _finalDesignRepository.SaveFinalDesign(fd.GetRepoFinalDesign());


        }
    }
}
