using MyGym.Application.Repositories;
using MyGym.Domain.Enities.Base;
using MyGym.Persistance.Contexts;

namespace MyGym.Persistance.Repositories
{
    public class WriteRepository<T> : Repository<T>, IWriteRepository<T> where T : BaseEntity
    {
        public WriteRepository(AppDbContext context) : base(context)
        {
        }

        public Task<bool> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(List<T> model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
