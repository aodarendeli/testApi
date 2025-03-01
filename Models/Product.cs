using System.ComponentModel.DataAnnotations.Schema;

namespace FreeApi.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Category> Categories { get; set; } = new();

    }
}