using Microsoft.EntityFrameworkCore;
using MyGym.Application.Repositories;
using MyGym.Domain.Enities.Base;
using MyGym.Persistance.Contexts;

namespace MyGym.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
    }
}
