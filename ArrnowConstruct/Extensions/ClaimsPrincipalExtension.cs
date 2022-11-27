using System.Security.Claims;
using ArrnowConstruct.Core.Constants;

namespace ArrnowConstruct.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdministrator(this ClaimsPrincipal user)
        {
            return user.IsInRole(RoleConstants.Administrator);
        }
    }
}
