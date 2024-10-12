using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Day6Demo.ViewModels
{
    [Keyless]
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Must Enter username")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Must Enter Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }  // This property will be used to track the "Remember Me" checkbox
    }
}
