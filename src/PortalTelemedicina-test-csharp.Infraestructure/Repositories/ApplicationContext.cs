using Microsoft.EntityFrameworkCore;
using PortalTelemedicina_test_csharp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTelemedicina_test_csharp.Infraestructure.Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(k => k.Id);

                e.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
