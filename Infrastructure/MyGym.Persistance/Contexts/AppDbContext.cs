using Microsoft.EntityFrameworkCore;
using MyGym.Domain.Enities;
using MyGym.Domain.Enities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Persistance.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options) {}
        public DbSet<Sport> Sports{ get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in datas)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.ModifiedDate = DateTime.UtcNow
                };
                
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
