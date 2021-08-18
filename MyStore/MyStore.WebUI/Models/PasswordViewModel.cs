using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyStore.WebUI.Models
{
    public class PasswordViewModel
    {
        //[Required]
        //[Display(Name = "Current password")]
        //[DataType(DataType.Password)]
        //[AllowHtml]
        //public string CurrentPassword { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "The new password cannot be longer than 10 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "The new password cannot contain special characters.")]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The confirm new password cannot be longer than 10 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([a-zA-Z0-9]+)$", ErrorMessage = "The confirm new password cannot contain special characters.")]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The confirm new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class PasswordResetModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}