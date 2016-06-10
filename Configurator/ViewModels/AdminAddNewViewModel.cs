using Configurator.DataLayer;
using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class AdminAddNewViewModel
    {
        public IList<ProductModel> Products { get; set; }
        public int UserId { get; set; }

    }
}