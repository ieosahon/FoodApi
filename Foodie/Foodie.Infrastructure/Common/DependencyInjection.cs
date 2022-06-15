


using Foodie.Application.Common.Interfaces.Auth;
using Foodie.Application.Common.Interfaces.Auth.Services;
using Foodie.Infrastructure.Common.Implemetations.Auth;
using Foodie.Infrastructure.Common.Implemetations.Auth.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGen, JwtTokenGen>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}