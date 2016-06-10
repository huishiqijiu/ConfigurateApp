using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IFinalDesignRepository
    {
        byte[] GetImage();
        void SaveFinalDesign(FinalDesign fd);
        bool HasImg(string code);
        string GetImgPath(string code);

    }
}
