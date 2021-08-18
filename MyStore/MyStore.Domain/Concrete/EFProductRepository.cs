using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace MyStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Vote> Votes => context.Votes;

        public Product DeleteProduct(int productID)
        {
            var dbEntity = context.Products.Find(productID);
            if(dbEntity != null)
            {
                context.Products.Remove(dbEntity);
                context.SaveChanges();
            }
            return dbEntity;
        }

        public IEnumerable<Vote> ProductVotes(int productID)
        {
            return context.Votes.Where(v => v.ProductID == productID);
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                var dbEntity = context.Products.Find(product.ProductID);
                if(dbEntity != null)
                {
                    dbEntity.Name = product.Name;
                    dbEntity.Description = product.Description;
                    dbEntity.Price = product.Price;
                    dbEntity.Category = product.Category;
                    dbEntity.ImageData = product.ImageData;
                    dbEntity.ImageMimeType = product.ImageMimeType;
                    dbEntity.ImagePath = product.ImagePath;
                }
            }
            context.SaveChanges();
        }

        public void SaveProductVote(Vote vote)
        {
            context.Votes.Add(vote);
            context.SaveChanges();
        }

        public List<Vote> ProductVotes(int productID, string orderBy)
        {
            List<Vote> productVotes;
            //blind sql injection
            var sql = $"Select v.VoteID, v.ProductID, v.UserID, v.Comments, u.FirstName + ' ' +  u.LastName as UserName From Votes v inner join Users u on v.UserID = u.UserID Where ProductID={productID} Order By {orderBy}";
            var context = new EFDbContext();
            productVotes = context.Database
                .SqlQuery<Vote>(sql)
                .ToList();

            //todo: Session-3-2. Blind SQL Injection Fix
            //fix 1: LINQ
            //productVotes = ProductVotesFix1(productID, orderBy);

            //fix 2: parameter 
            //productVotes = ProductVotesFix2(productID, orderBy);



            return productVotes;
        }


        

        //todo: Session-3-2.1 Blind SQL Injection Fix by LINQ & system.Linq.Dynamic
        public List<Vote> ProductVotesFix1(int productID, string orderBy)
        {
            var pvs = (from v in context.Votes
                                join u in context.Users on v.UserID equals u.UserID
                                where v.ProductID == productID
                                select new
                                {
                                    v.VoteID,
                                    v.ProductID,
                                    v.UserID,
                                    v.Comments,
                                    UserName = u.FirstName + " " + u.LastName
                                }).OrderBy(orderBy)
                      .ToList()
                    .Select(v => new Vote
                    {
                        VoteID = v.VoteID,
                        ProductID = v.ProductID,
                        UserID = v.UserID,
                        Comments = v.Comments,
                        UserName = v.UserName
                    });
            var productVotes = pvs.ToList();
            return productVotes;
        }

        //todo: Session-3-2.2 Blind SQL Injection Fix by Parameters & system.Linq.Dynamic
        public List<Vote> ProductVotesFix2(int productID, string orderBy)
        {
            var pvs = context.Database
                .SqlQuery<Vote>($"Select v.VoteID, v.ProductID, v.UserID, v.Comments, u.FirstName + ' ' +  u.LastName as UserName From Votes v inner join Users u on v.UserID = u.UserID Where ProductID=@p0"
                , productID).OrderBy(orderBy);
            var productVotes = pvs.ToList();
            return productVotes;
        }

    }
}
