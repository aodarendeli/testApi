using FreeApi.Data;
using FreeApi.Dtos.Product;
using FreeApi.Mappers.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreeApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.Productions.Include(p => p.Categories).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return product.ToProductDto();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(CreateProductDto productDto)
        {
            var categories = await _context.Categories.Where(c => productDto.CategoryIds.Contains(c.Id)).ToListAsync();
            var product = productDto.ToProductFromCreateDTO(categories);
            _context.Productions.Add(product);
            await _context.SaveChangesAsync();
            return product.ToProductDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _context.Productions.Include(p => p.Categories).ToListAsync();
            return products.Select(p => p.ToProductDto()).ToList();
        }
    }
}