using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Infrastructure.EF.Config;
using NotificationSchedulingSystem.Infrastructure.EF.Models;

namespace NotificationSchedulingSystem.Infrastructure.EF.Contexts
{
    internal class ReadDbContext : DbContext
    {
        public DbSet<CompanyReadModel> Companies { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("schedule");

            var configuration = new ReadConfiguration();

            modelBuilder.ApplyConfiguration<CompanyReadModel>(configuration);
            modelBuilder.ApplyConfiguration<NotificationReadModel>(configuration);
        }
    }
}
