using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class AdminItemTypesViewModel
    {
        public IList<ItemTypeModel> ItemTypes { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}