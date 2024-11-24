using System.Security.Claims;

namespace CarsPlatform.Web.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserFullName(this ClaimsPrincipal claimsPrinciple)
        {
            return claimsPrinciple.FindFirst("FullName")!.Value;
        }
    }
}
