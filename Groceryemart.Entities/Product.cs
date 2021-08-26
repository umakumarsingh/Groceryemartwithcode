using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryEmart.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public Double Amount { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }
        public string photo { get; set; }
        public int CatId { get; set; }
        public ProductOrder ProductOrder { get; set; }
    }
}
