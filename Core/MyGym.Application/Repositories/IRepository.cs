using Microsoft.EntityFrameworkCore;
using MyGym.Domain.Enities.Base;

namespace MyGym.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
