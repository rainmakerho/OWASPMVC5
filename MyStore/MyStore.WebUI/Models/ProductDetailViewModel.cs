using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Vote> ProductVotes { get; set; }

        public int CurrentUserId { get; set; }

    }
}