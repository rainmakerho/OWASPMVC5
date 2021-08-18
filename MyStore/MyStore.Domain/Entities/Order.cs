using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities
{
    public class Order
    {
        public ObjectId OrderID { get; set; }
        public string UserEmail { get; set; }
        public List<CartLine> CartLines { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public Order()
        {}

        public Order(string email, List<CartLine> cartLines, ShippingDetails shippingDetails)
        {
            OrderID = ObjectId.NewObjectId();
            UserEmail = email;
            CartLines = cartLines;
            ShippingDetails = shippingDetails;
        }
    }
}
