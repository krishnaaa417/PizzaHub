using System.ComponentModel.DataAnnotations;

namespace ePizza.UI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="please enter the username")]
        [EmailAddress(ErrorMessage ="email address is not in the correct format")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
