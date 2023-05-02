using MyGym.Application.Repositories;
using MyGym.Domain.Enities;
using MyGym.Persistance.Contexts;

namespace MyGym.Persistance.Repositories
{
    public class SportReadRepository : ReadRepository<Sport>, ISportReadRepository
    {
        public SportReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
