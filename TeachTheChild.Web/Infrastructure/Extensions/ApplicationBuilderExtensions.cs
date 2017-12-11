namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Globalization;
    using TeachTheChild.Data;
    using TeachTheChild.Web.Infrastructure.Constants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TeachTheChildDbContext>();
                context.Database.Migrate();
            }

            return app;
        }

        public static IApplicationBuilder UseRequestLocalizationExtended(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo(WebConstants.DefaultEnglishCulture),
                new CultureInfo(WebConstants.BulgarianNeutralCulture),
                new CultureInfo(WebConstants.SpanishNeutralCulture)
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(WebConstants.DefaultEnglishCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return app;
        }
    }
}
