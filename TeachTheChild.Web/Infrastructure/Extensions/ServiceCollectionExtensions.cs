namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;
    using TeachTheChild.Data;

    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.WebServices;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes() 
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementaion = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementaion));

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
