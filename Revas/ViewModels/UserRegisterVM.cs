using System.ComponentModel.DataAnnotations; 

namespace Revas.ViewModels
{
    public class UserRegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Password { get; set; }
        [Compare("Password")]
        [Required(ErrorMessage = "Email is required")]
        public string ConfirmPassword { get; set; }

    }
}
