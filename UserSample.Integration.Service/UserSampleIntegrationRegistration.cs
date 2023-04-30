
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserSample.Business.Service.Services.Abstracts;
using UserSample.Integration.Service.Services;

namespace UserSample.Business.Service
{
    public static class UserSampleIntegrationRegistration
    {
        public static IServiceCollection AddUserSampleIntegrationServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddScoped<IUserIntegrationService, UserIntegrationService>();
            return services;
        }
    }
}
