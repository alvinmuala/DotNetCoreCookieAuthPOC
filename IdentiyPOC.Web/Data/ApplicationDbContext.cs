using IdentityPOC.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityPOC.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserLogin> Logins { get; set; }
    }
}
