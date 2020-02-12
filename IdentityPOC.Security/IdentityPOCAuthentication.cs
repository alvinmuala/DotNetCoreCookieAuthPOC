using IdentityPOC.Common.Models;
using IdentityPOC.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IdentityPOC.Security
{
    public class IdentityPOCAuthentication
    {
        public static async void SignOut(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public static LoginResult Login(ApplicationDbContext dbContext, HttpContext httpContext, UserLogin login)
        {
            var claims = GetClaims(login);

            var user = dbContext.Logins
                .FirstOrDefault(r => r.Username == login.Username && r.Password == login.Password);

            if(user == null)
            {
                return LoginResult.MemberNotFound;
            }

            if (user != null)
            {
                CreateIdentityAsync(httpContext, claims);

                return LoginResult.Success;
            }

            return LoginResult.Failed;
        }

        private static async void CreateIdentityAsync(HttpContext context, List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
        private static List<Claim> GetClaims(UserLogin login)
        {
            var claims = new List<Claim>()
            {
                new Claim("Username", login.Username),
            };

            return claims;
        }

    }

    public enum LoginResult
    {
        MemberNotFound,
        Success,
        Failed
    }


}
