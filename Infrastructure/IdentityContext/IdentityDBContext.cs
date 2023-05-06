
using Infrastructure.CarModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IdentityContext
{
    public class AppIdentityDBContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}