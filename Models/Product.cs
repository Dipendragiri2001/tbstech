using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TBSTech.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter Product Description")]

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Please enter Product Image")]

        public string ImageUrl { get; set; }
        
    }
}