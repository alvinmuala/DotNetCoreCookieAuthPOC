using AuthCookiePOC.Common.Models;
using AuthCookiePOC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AuthCookiePOC.Web
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Logins.Any())
                {
                    return;
                }

                context.Logins.AddRange(
                    new UserLogin
                    {
                        Username = "280493",
                        Password = "Password123$"
                    },
                    new UserLogin
                    {
                        Username = "990115",
                        Password = "Sunshine2020"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
