namespace FreeApi.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<int> CategoryIds { get; set; } = new();
    }
}
