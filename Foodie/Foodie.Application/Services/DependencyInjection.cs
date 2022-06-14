using Foodie.Application.Services.Auth.Implementation;
using Foodie.Application.Services.Auth.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Application.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}