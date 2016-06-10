using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class AdminPartsViewModel
    {
        public IList<PartModel> Parts { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CodeProd { get; set; }
    }
}