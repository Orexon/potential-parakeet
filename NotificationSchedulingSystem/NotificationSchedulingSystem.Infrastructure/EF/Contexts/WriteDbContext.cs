using Microsoft.EntityFrameworkCore;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Infrastructure.EF.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("schedule");

            var configuration = new WriteConfiguration();

            modelBuilder.ApplyConfiguration<Company>(configuration);
            modelBuilder.ApplyConfiguration<Notification>(configuration);
        }
    }
}
