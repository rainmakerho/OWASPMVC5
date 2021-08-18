using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyStore.Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter a email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        //todo: Session-5.1 修正密碼字元
        //todo: Session-5.2 修正密碼允許特殊字元
        [Required, AllowHtml]
        [StringLength(10, ErrorMessage = "The password cannot be longer than 10 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "The password cannot contain special characters.")]
        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public bool? IsAdmin { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Token { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? TokenCreTime { get; set; }
    }
}
