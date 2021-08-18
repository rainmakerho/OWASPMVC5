using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        Order ProcessOrder(User user, Cart cart, ShippingDetails shippingDetails);
        IEnumerable<Order> SearchOrders(string email, string productName);
    }
}
