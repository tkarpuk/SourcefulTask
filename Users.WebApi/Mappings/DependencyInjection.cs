using Microsoft.Extensions.DependencyInjection;

namespace Users.WebApi.Mappings
{
    public static class DependencyInjection
    {
        public static void AddAutomapperExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
