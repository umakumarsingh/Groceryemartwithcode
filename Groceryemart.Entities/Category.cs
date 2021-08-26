using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GroceryEmart.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public int CatId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}
