using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IOrderService
    {
        OrderModel GetOrderById(int id);
        IList<OrderModel> GetAllOrders(int userId);
        IList<OrderModel> GetOrders();
        void SaveOrder(OrderModel order);
        bool UpdateOrder(OrderModel order);
        bool DeleteOrder(int id);
    }
}
