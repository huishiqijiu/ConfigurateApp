using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Configurator.ViewModels
{
    public class OrdersViewModel
    {
        public IList<OrderModel> UsersOrders { get; set; }
        public IList<OrderModel> AllOrders { get; set; }
    }
}