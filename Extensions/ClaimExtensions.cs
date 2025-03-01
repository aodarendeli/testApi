using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FreeApi.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname" ||  
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" ||      
                c.Type == "given_name" ||                                                      
                c.Type == ClaimTypes.Name);                                                    

            return claim?.Value ?? "Unknown"; 
        }

    }
}