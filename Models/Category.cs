using System.ComponentModel.DataAnnotations.Schema;

namespace FreeApi.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<Product> Products { get; set; } = new();

    }
}