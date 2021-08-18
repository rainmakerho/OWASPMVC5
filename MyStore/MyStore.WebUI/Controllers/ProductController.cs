using MyStore.Domain.Abstract;
using MyStore.Domain.Concrete;
using MyStore.Domain.Entities;
using MyStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.SqlClient;

namespace MyStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        private IUserRepository userRepository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository,
            IUserRepository userRepository)
        {
            this.repository = productRepository;
            this.userRepository = userRepository;
        }

        [ValidateInput(false)]
        public ViewResult List(string category, int page=1, string searchTerm="")
        {
            // Reading from query string to demonstrate HTTP verb tampering
            var searchTermQuery = Request.Unvalidated.QueryString["searchTerm"];
            if (!string.IsNullOrEmpty(searchTerm) && searchTerm.Contains("<"))
            {
                return View("IllegalChar");
            }

            var searchProducts = repository.Products
                .Where(p => (category == null || p.Category == category)
                    && (p.Category.ToLower().Contains(searchTerm.ToLower())
                    || p.Description.ToLower().Contains(searchTerm.ToLower())
                    || p.Name.ToLower().Contains(searchTerm.ToLower()))
                );


            var vm = new ProductsListViewModel
            {
                Products = searchProducts.OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = searchProducts.Count()
                },
                CurrentCategory = category
            };


            ViewBag.RawSearchTerm = searchTerm;
            if (!string.IsNullOrEmpty(Request.QueryString["searchTerm"]))
            {
                searchTerm = searchTerm.Replace("<", "").Replace(">", "").Replace("/", "&#47;");
            }
            ViewBag.SearchTerm = searchTerm;
            ViewBag.EncodedSearchTerm = searchTerm;
            return View(vm);
        }

        public FileContentResult GetImage(int productId)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                if (product.ImageData != null)
                {
                    return File(product.ImageData, product.ImageMimeType);
                }
                if (!string.IsNullOrWhiteSpace(product.ImagePath))
                {
                    var imageFilePath = Server.MapPath(@"~\Uploads\") + product.ImagePath;
                    return File(System.IO.File.ReadAllBytes(imageFilePath), product.ImageMimeType);  
                }
            }
            return null;
        }


        public ViewResult Detail(int productId, string orderBy = "UserID")
        {
            try
            {
                var product = repository.Products
                .Single(p => p.ProductID == productId);
                //add votes
                var productVotes = repository.ProductVotes(productId, orderBy);
                //add votes
                var user = userRepository.Users.FirstOrDefault(u => u.Email.ToLower() == User.Identity.Name.ToLower());
                var productDetail = new ProductDetailViewModel
                {
                    Product = product,
                    ProductVotes = productVotes,
                    CurrentUserId = user?.UserID ?? 0
                };
                ViewBag.TotalVotes = repository.Votes.Count();
                ViewBag.FirstName = user?.FirstName;
                ViewBag.LastName = user?.LastName;
                return View(productDetail);
            }
            catch (Exception)
            {
                return View("IllegalChar");
            }
            
        }
    }
}