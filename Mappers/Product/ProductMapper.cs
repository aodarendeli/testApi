using FreeApi.Dtos.Product;
using FreeApi.Models;

namespace FreeApi.Mappers.Products
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDto(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = product.CreatedAt,
                CategoryIds = product.Categories.Select(c => c.Id).ToList()
            };
        }

        public static Product ToProductFromCreateDTO(this CreateProductDto productDto, List<Category> categories)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Categories = categories
            };
        }

        public static void UpdateProductFromDTO(this Product product, UpdateProductDto productDto, List<Category> categories)
        {
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.Categories = categories;
        }
    }
}
