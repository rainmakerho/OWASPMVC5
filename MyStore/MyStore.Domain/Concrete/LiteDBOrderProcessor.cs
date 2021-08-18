using LiteDB;
using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Concrete
{
    public class LiteDBOrderProcessor : IOrderProcessor
    {
        private readonly string dbPath;
        const string dbName = "Store.db";
        public LiteDBOrderProcessor()
        {
            this.dbPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString()
                , dbName);
        }
        public Order ProcessOrder(User user, Cart cart, ShippingDetails shippingDetails)
        {
            var order = new Order(user.Email, cart.Lines.ToList(), shippingDetails);
            using (var db = new LiteDatabase(dbPath))
            {
                //// Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Order>("Order");
                
                col.Insert(order);
            }
            return order;
        }

        public IEnumerable<Order> SearchOrders(string email, string productName)
        {
            //SELECT $ FROM Order
            //where $.UserEmail = 'rm@rm.com'
            //AND $.CartLines[*].Product.Name ANY LIKE '活性碳口罩%' 
            IEnumerable<Order> result;
            using (var db = new LiteDatabase(dbPath))
            {
                //// Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Order>("Order");
                col.EnsureIndex(o => o.UserEmail);
                var query = "$.UserEmail = '" + email + "' ";
                query += "AND $.CartLines[*].Product.Name ANY LIKE '%" + productName + "%'";
                result = col.Find(query).ToList();
            }
            //todo: Session-3-3 NoSQL Injection Fix
            //fix: LINQ
            //result = SearchOrdersFix(email, productName);
            return result;
        }

        //todo: Session-3-3.1 NoSQL Injection Fix by LINQ
        private IEnumerable<Order> SearchOrdersFix(string email, string productName)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                //// Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Order>("Order");
                col.EnsureIndex(o => o.UserEmail);
                var result = col
                .Find(Query.EQ("UserEmail", email))
                .Where(o => o.CartLines
                  .Any(p =>
                  p.Product.Name.IndexOf(productName, StringComparison.InvariantCultureIgnoreCase) 
                  != -1))
                .ToList();
                return result;
            }

            
        }
    }

    
}
