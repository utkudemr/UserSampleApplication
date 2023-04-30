
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Concretes;
using UserSample.Business.Service.Features.Abstracts;
using UserSample.Business.Service.Features.Concretes;
using UserSample.Business.Service.Services.Abstracts;

namespace UserSample.Business.Service
{
    public static class UserSampleBusinessRegistration
    {
        public static IServiceCollection AddUserSampleBusinessServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddScoped<ICreateCustomerService, CreateCustomerService>();
            services.AddScoped<IGetCustomerListFilterService, GetCustomerListFilterService>();
            services.AddScoped<IGetCustomerService, GetCustomerService>();
            services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();
            return services;
        }
    }
}
