using System;
using System.Security.Claims;

namespace WebApp.Common
{
    public static class ExtMethod
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return null;
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
