using Microsoft.EntityFrameworkCore;

namespace DbConfiguration
{
    public class ApplicationSettingsContext : DbContext
    {
        public ApplicationSettingsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ApplicationSetting> Settings { get; set; }
    }
}
