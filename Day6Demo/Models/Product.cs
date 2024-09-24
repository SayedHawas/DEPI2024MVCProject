using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day6Demo.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Product Name ")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter Your Price ")]
        [Remote("CheckPrice", "Products", AdditionalFields = "ProductName", ErrorMessage = "Price Must Less than 100000")]
        public decimal Price { get; set; }

        public string? Photo { get; set; }
    }

}
