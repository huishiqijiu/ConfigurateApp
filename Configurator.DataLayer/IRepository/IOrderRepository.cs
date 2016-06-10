using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        IList<Order> GetAllOrders(int userId);
        IList<Order> GetOrders();
        void SaveOrder(Order item);
        bool UpdateOrder(Order item);
        bool DeleteOrder(int id);
    }
}
