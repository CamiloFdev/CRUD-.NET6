using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.AggregateRoots;
using Prueba.Adapters.EntityFramework.Relations;

namespace Prueba.Adapters.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users => Set <User>();

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
          
        }
    }
}
