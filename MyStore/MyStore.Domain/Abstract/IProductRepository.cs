using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);

        IEnumerable<Vote> Votes { get; }
        IEnumerable<Vote> ProductVotes(int productID);

        void SaveProductVote(Vote vote);

        List<Vote> ProductVotes(int productId, string orderBy);
    }
}
