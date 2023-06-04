using MyGym.Domain.Enities.Base;
using System.Linq.Expressions;

namespace MyGym.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = false);
        IQueryable<T> FindAll(Expression<Func<T,bool>> expression, bool isTracking = false);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> expression, bool isTracking = false);
        Task<T> GetByIdAsync(int id, bool isTracking = false);
    }
}
