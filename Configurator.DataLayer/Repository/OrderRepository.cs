using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAllOrders(int userId)
        {
            return db.Orders.Where(x => x.UserId == userId).ToList();
        }
        public IList<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
