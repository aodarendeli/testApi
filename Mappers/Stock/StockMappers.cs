using FreeApi.Dtos;
using FreeApi.Mappers.Comments;
using FreeApi.Models;

namespace FreeApi.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                ComponyName = stockModel.ComponyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCup = stockModel.MarketCup,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStackFromCreateDTO(this CreateStockRequest stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                ComponyName = stockDto.ComponyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCup = stockDto.MarketCup,
            };
        }
    }
}