#region Usings
using Microsoft.EntityFrameworkCore;
using knowledge.common.entities;
using knowledge.common.entities.Types;
#endregion

namespace knowledge.common.mysql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DatabaseSeeder.SeedCustomer(modelBuilder);           

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Trace> Traces { get; set; }
        public DbSet<TraceDetail> TraceDetails { get; set; }
    }
}
