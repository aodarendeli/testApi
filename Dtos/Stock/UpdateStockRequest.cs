using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeApi.Dtos
{
    public class UpdateStockRequest
    {
        public string Symbol { get; set; } = string.Empty;
        public string ComponyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCup { get; set; }
    }
}