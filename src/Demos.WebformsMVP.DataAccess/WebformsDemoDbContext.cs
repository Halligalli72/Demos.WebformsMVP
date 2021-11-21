using Demos.WebformsMVP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demos.WebformsMVP.DataAccess
{
    public class WebformsDemoDbContext : DbContext, IDbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public WebformsDemoDbContext(DbContextOptions<WebformsDemoDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebformsDemoDbContext).Assembly);
        }

    }
}
