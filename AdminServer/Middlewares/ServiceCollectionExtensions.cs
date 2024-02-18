using AdminService.AdminSection;

namespace AdminServer.Middlewares
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            #region AdminSection
            services.AddScoped<IAdminUserService, AdminService.AdminSection.AdminUserService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            #endregion
            return services;
        }
    }
}
