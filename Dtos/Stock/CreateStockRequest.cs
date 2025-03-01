using System.ComponentModel.DataAnnotations;

namespace FreeApi.Dtos
{
    public class CreateStockRequest
    {
        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 character")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [MaxLength(10, ErrorMessage = "Name must be at most 10 character")]
        public string ComponyName { get; set; } = string.Empty;

        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [Range(1, 1000000)]
        public decimal Purchase { get; set; }
        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [MaxLength(10, ErrorMessage = "Industry must be at most 10 character")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        // [MinLength(5, ErrorMessage = "Symbol must be at least 5 character")]
        [Range(1, 500000)]
        public long MarketCup { get; set; }
    }
}