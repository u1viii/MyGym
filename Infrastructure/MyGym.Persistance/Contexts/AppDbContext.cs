using Microsoft.EntityFrameworkCore;
using MyGym.Domain.Enities;
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
    }
}
