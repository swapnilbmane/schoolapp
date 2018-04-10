using System.ComponentModel.DataAnnotations;

namespace schoolapp.api.models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public PersonType Type { get; set; }
    }
}