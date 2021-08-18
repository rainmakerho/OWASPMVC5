using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities
{
    public class ShippingDetails
    {

        [Required(ErrorMessage="Please enter a name")]
        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the TEL")]
        [Display(Name = "連絡電話")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Please enter the credit card number")]
        [Display(Name="信用卡號")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        [Display(Name = "地址")]
        public string  Address { get; set; }

        public bool GiftWrap { get; set; }

        [Display(Name = "其他注意事項")]
        //[JsonProperty(TypeNameHandling = TypeNameHandling.All)]
        public dynamic Others { get; set; }
        //dynamic, object
    }

    
}
