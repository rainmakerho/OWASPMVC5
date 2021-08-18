using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MyStore.WebUI.Models
{
    public class PasswordResetVerificationViewModel
    {
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [AllowHtml]
        [StringLength(200, ErrorMessage = "The password cannot be longer than 200 characters.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [StringLength(200, ErrorMessage = "The password cannot be longer than 200 characters.")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }
    }
}