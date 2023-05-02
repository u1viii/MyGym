using MyGym.Application.Repositories;
using MyGym.Domain.Enities;
using MyGym.Persistance.Contexts;

namespace MyGym.Persistance.Repositories
{
    internal class SportWriteRepository : WriteRepository<Sport>, ISportWriteRepository
    {
        public SportWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
