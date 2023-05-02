using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGym.Application.Repositories;
using MyGym.Persistance.Contexts;
using MyGym.Persistance.Repositories;

namespace MyGym.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ISportReadRepository, SportReadRepository>();
            services.AddScoped<ISportWriteRepository, SportWriteRepository> ();
        }
    }
}
