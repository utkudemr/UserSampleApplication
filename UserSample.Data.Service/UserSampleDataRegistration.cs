using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Data.Service.EF;

namespace UserSample.Data.Service
{
    public static class UserSampleDataRegistration
    {
        public static IServiceCollection AddUserSampleDataServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddDbContext<UserSampleContext>(options =>
                                                         options.UseSqlServer(
                                                             configuration.GetConnectionString("UserSampleConnectionString")));
            return services;
        }
    }
}
