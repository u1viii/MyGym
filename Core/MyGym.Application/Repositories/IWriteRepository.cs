using MyGym.Domain.Enities.Base;

namespace MyGym.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity 
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddAsync(List<T> model);
        bool Update(T model);
        bool Remove(T model);
        bool Remove(int id);
        Task SaveChangesAsync();
    }
}
