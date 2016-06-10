using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.DataLayer;

namespace Configurator.DataLayer.Repository
{
    public class FinalDesignRepository : IFinalDesignRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        //ProductConfiguratorEntities db = new ProductConfiguratorEntities();
        public byte[] GetImage()
        {
            throw new NotImplementedException();
        }

        public string GetImgPath(string code)
        {
            if (db.FinalDesigns.FirstOrDefault(x => x.DesignCode == code) !=null)
                return db.FinalDesigns.FirstOrDefault(x => x.DesignCode == code).Image;
            else
                return "";
        
        }

        public bool HasImg(string code)
        {
            if (db.FinalDesigns.FirstOrDefault(x => x.DesignCode == code) == null)
                return false;
            else if (db.FinalDesigns.FirstOrDefault(x => x.DesignCode == code).Image == null)
                return false;
            else return true;
        }

        public void SaveFinalDesign(FinalDesign fd)
        {
            db.FinalDesigns.Add(fd);
            db.SaveChanges();
        }

       
    }
}
