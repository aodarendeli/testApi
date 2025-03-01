using FreeApi.Data;
using FreeApi.Interfaces;
using FreeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeApi.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser appUser)
        {
            return await _context.Portfolios.Where(s => s.AppUserId == appUser.Id).Select(s => new Stock
            {
                Id = s.StockId,
                Symbol = s.Stock.Symbol,
                ComponyName = s.Stock.ComponyName,
                Purchase = s.Stock.Purchase,
                LastDiv = s.Stock.LastDiv,
                Industry = s.Stock.Industry,
                MarketCup = s.Stock.MarketCup,
            }).ToListAsync();
        }
    }
}