using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DbConfiguration
{
    public static class RemoteOptionsExtension
    {
        public static IServiceCollection AddRemoteOptions(this IServiceCollection services)
        {
            services.AddSingleton<RemoteOptionsEntity>();
            services.AddScoped(typeof(IDbOptions<>), typeof(DbOptions<>));

            return services;
        }

        public static IApplicationBuilder Options<TEntity>(this IApplicationBuilder applicationBuilder, string key) where TEntity : class
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var options = serviceProvider.GetRequiredService<RemoteOptionsEntity>();

            options.Add<TEntity>(key);

            return applicationBuilder;
        }
    }
}
