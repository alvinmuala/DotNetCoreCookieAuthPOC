using System.Collections.Generic;
using System.Security.Claims;
using IdentityPOC.Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace IdentityPOC.Security
{
    public class IdentityPOCAuthentication
    {
        public static async void SignOut(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public static LoginResult Login(HttpContext context, UserLogin login)
        {
            var claims = GetClaims(login);

            var user = string.Empty;

            if(user != null)
            {
                CreateIdentityAsync(context, claims);

                return LoginResult.Success;
            }

            return LoginResult.Failed;
        }

        private static async void CreateIdentityAsync(HttpContext context, List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await context.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
        private static List<Claim> GetClaims(UserLogin login)
        {
            var claims = new List<Claim>()
            {
                new Claim("Usercode", login.Usercode),
                new Claim("Password", login.Password)
            };

            return claims;
        }        

    }

    public enum LoginResult
    {
        Success,
        Failed
    }


}
