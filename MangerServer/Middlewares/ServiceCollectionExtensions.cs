using MangerService.MangerSection;

namespace MangerServer.Middlewares
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            #region MangerSection
            services.AddScoped<IMangerService, MangerService.MangerSection.MangerService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            #endregion
            return services;
        }
    }
}
