using Microsoft.Extensions.DependencyInjection;
using NotificationSchedulingSystem.Core.Factories;
using NotificationSchedulingSystem.Core.Policies;
using NotificationSchedulingSystem.Shared.Commands;

namespace NotificationSchedulingSystem.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ICompanyFactory, CompanyFactory>();
            services.Scan(b => b.FromAssemblies(typeof(ICompanyPolicy).Assembly)
                 .AddClasses(c => c.AssignableTo<ICompanyPolicy>())
                 .AsImplementedInterfaces()
                 .WithSingletonLifetime());


            return services;
        }
    }
}
