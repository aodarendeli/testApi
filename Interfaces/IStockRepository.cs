using FreeApi.Dtos;
using FreeApi.Helpers;
using FreeApi.Models;

namespace FreeApi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock?> GetBySymbolAsync(string symbol);

        Task<Stock> CreateAsync(Stock stock);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequest stock);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}