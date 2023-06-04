using Microsoft.EntityFrameworkCore;
using MyGym.Application.Repositories;
using MyGym.Domain.Enities.Base;
using MyGym.Persistance.Contexts;
using System.Linq.Expressions;

namespace MyGym.Persistance.Repositories
{
    public class ReadRepository<T> : Repository<T>, IReadRepository<T> where T : BaseEntity
    {
        public ReadRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            var query = Table.Where(expression).AsQueryable();
            return isTracking ? query : query.AsNoTracking();
        }

        public IQueryable<T> GetAll(bool isTracking = false)
        {
            var query = Table.AsQueryable();
            return isTracking ? query : query.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id, bool isTracking = false)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync(expression);
        }

        //public IQueryable<T> FindAll(Expression<Func<T, bool>> expression, bool isTracking = false)
        //{
        //    var query = Table.Where(expression).AsQueryable();
        //    return isTracking ? query : query.AsNoTracking();
        //}

        //public IQueryable<T> GetAll(bool isTracking = false)
        //{
        //    var query = Table.AsQueryable();
        //    return isTracking ? query : query.AsNoTracking();
        //} 

        //public async Task<T> GetByIdAsync(int id, bool isTracking = false)
        //{
        //var query = Table.AsQueryable();
        //    if (!isTracking)
        //        query = query.AsNoTracking();
        //    return await query.FirstOrDefaultAsync(t => t.Id == id);
        //}

        //public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
        //{
        //    var query = Table.AsQueryable();
        //    if (!isTracking)
        //    {
        //        query = query.AsNoTracking();
        //    }
        //    return await query.SingleOrDefaultAsync(expression);
        //}
    }
}
