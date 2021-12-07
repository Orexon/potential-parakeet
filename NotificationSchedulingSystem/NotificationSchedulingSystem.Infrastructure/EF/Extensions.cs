using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationSchedulingSystem.Application.Services;
using NotificationSchedulingSystem.Core.Repositories;
using NotificationSchedulingSystem.Infrastructure.EF.Contexts;
using NotificationSchedulingSystem.Infrastructure.EF.Options;
using NotificationSchedulingSystem.Infrastructure.EF.Repositories;
using NotificationSchedulingSystem.Infrastructure.EF.Services;
using NotificationSchedulingSystem.Shared.Options;

namespace NotificationSchedulingSystem.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyRepository, SqlCompanyRepository>();
            services.AddScoped<ICompanyReadService, SqlCompanyReadService>();

            var options = configuration.GetOptions<SqlOptions>("ConnectionStrings");

            string connectionString = configuration.GetConnectionString("DefaultConnection");
           
            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(connectionString));

            return services;
        }
    }
}
