using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Day6Demo.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string? City { get; set; }
    }
}
