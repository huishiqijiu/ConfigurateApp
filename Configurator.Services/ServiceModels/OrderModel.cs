using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class OrderModel
    {
        public OrderModel(Order order)
        {
            Id = order.Id;
            ProductCode = order.ProductCode;
            TotalPrice = order.TotalPrice;
            DeliverDate = order.DeliverDate;
            UserId = order.UserId;
           
        }
        public OrderModel()
        {

        }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliverDate { get; set; }
        public int UserId { get; set; }
       

        public Order GetRepoOrder()
        {
            return new Order
            {
                Id = Id,
                ProductCode = ProductCode,
                TotalPrice = TotalPrice,
                DeliverDate = DeliverDate,
                UserId = UserId,
               
            };
        }
    }
}
