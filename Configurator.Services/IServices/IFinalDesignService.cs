using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IFinalDesignService
    {
        byte[] GetImage();
        void SaveFinalDesign(FinalDesignModel fd);
        bool HasImg(string code);
        string GetImagePath(string code);
    }
}
