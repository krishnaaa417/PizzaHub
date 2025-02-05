using System.ComponentModel.DataAnnotations;

namespace ePizza.UI.Models
{
    public class SignUpViewModel 
    {
        [Required(ErrorMessage ="This property is required")]
        [EmailAddress(ErrorMessage ="please enter a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="This property is required")]
        [StringLength(20,ErrorMessage ="Name should not be more than 20 characters")]
        public string Completename { get; set; }

        [Required(ErrorMessage ="This property is required")]
        [MinLength(3, ErrorMessage = "Password should be more than 3 characters in Length")]
        [MaxLength(10, ErrorMessage = "Password should not be more than 10 characters in Length")]
        public string City { get; set; }

        [Required(ErrorMessage = "This property is required")]
        [MinLength(3, ErrorMessage = "Password should be more than 3 characters in Length")]
        [MaxLength(10, ErrorMessage = "Password should not be more than 10 characters in Length")]
        public string Country { get; set; }

        [Required(ErrorMessage = "This property is required")]
        [MinLength(3, ErrorMessage = "Password should be more than 3 characters in Length")]
        [MaxLength(10, ErrorMessage = "Password should not be more than 10 characters in Length")]
        public string State { get; set; }

        public bool Terms { get; set; }
    }
}
