using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class AdminAddPicViewModel
    {
        public IList<ItemModel> UpbodyItems { get; set; }
        public IList<ItemModel> LowerBodyItems { get; set; }
        public IList<ItemModel> FootItems { get; set; }
        public FinalDesignModel Design { get; set; }
    }
}