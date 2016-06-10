using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class FinalDesignModel
    {
        public FinalDesignModel(FinalDesign fd)
        {
            Id = fd.Id;
            DesignCode = fd.DesignCode;
            Image = fd.Image;
        }
        public FinalDesignModel()
        {

        }
        public int Id { get; set; }
        public string DesignCode { get; set; }
        public string Image { get; set; }
       

        public FinalDesign GetRepoFinalDesign()
        {
            return new FinalDesign
            {
                Id = Id,
                DesignCode = DesignCode,
                Image = Image
            };
        }
    }
}
