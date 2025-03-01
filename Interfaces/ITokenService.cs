
using FreeApi.Models;

namespace FreeApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}