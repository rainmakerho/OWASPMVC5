using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyStore.Domain.Entities
{
    public class Vote
    {
        [HiddenInput(DisplayValue = false)]
        public int VoteID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        public string UserName { get; set; }
      
        public string Comments { get; set; }
    }
}
