using IdentityPOC.Common.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityPOC.Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Logins.Any())
                {
                    context.Logins.Add(new UserLogin() { Usercode = "280493", Password = "Password1234!" });
                    context.Logins.Add(new UserLogin() { Usercode = "150199", Password = "Sunshine$$" });

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
