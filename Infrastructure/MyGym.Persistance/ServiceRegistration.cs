using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGym.Persistance.Contexts;

namespace MyGym.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
