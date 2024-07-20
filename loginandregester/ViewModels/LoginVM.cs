using System.ComponentModel.DataAnnotations;

namespace loginandregester.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "password is required")]

        public string? Password { get; set; }
        [Display(Name = "remember me ")]
        public bool RemmemberMe { get; set; }
    }
}
