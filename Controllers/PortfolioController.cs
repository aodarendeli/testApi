using FreeApi.Extensions;
using FreeApi.Interfaces;
using FreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var userName = User.GetUserName();

            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("User name claim is missing.");
            }

            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
            {
                return NotFound("User not found.");
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }


        [HttpPost]
        [Authorize]

        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var userName = User.GetUserName();

            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("User name claim is missing.");
            }

            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
            {
                return NotFound("User not found.");
            }

            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                return NotFound("Stock not found.");
            }

            var portfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            if (portfolio.Any(x => x.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Stock already exists in the portfolio.");
            }

            var resultModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };
            await _portfolioRepository.CreateAsync(resultModel);

            if (resultModel == null)
            {
                return BadRequest("Failed to add stock to the portfolio.");
            }
            else
            {
                return Created();
            }
        }
    }
}