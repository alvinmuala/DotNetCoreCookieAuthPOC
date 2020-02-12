using IdentityPOC.Common.Models;
using IdentityPOC.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace IdentityPOC.Web
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
                        Usercode = "280493",
                        Password = "Password123$"
                    },
                    new UserLogin
                    {
                        Usercode = "990115",
                        Password = "Sunshine2020"
                    }
                );
            }
        }
    }
}
