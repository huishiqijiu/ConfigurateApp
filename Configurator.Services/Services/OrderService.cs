using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using Configurator.DataLayer.IRepository;

namespace Configurator.Services.Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepo;
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IList<OrderModel> GetAllOrders(int userId)
        {
            return _orderRepo.GetAllOrders(userId).Select(x => new OrderModel(x)).ToList();
        }

        public OrderModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<OrderModel> GetOrders()
        {
            return _orderRepo.GetOrders().Select(x => new OrderModel(x)).ToList();
        }

        public void SaveOrder(OrderModel order)
        {
            _orderRepo.SaveOrder(order.GetRepoOrder());
        }

        public bool UpdateOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
