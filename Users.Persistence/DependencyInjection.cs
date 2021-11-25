using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Interfaces;

namespace Users.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection
            services, string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUserDbContext>(provider =>
                provider.GetService<UserDbContext>());
        }
    }
}
