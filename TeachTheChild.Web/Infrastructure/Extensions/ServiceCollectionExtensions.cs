namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    using TeachTheChild.Services.Contracts;

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

            return services;
        }

        public static IServiceCollection AddAutoMapperCustomConfiguration(this IServiceCollection services)
        {
            //var mappingProfile = new AutoMapperProfile(
            //        Assembly.GetExecutingAssembly(),
            //        Assembly.GetAssembly(typeof(IService)));

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(mappingProfile);
            //});

            //var mapper = config.CreateMapper();

            //services.AddSingleton(mapper);
            //services.AddMvc();

            return services;
        }
    }
}
