using Microsoft.EntityFrameworkCore;
using ToAPI.Repos.Models;

namespace ToAPI.Repos
{
    public class LearndataContextb : DbContext
    {
        public LearndataContextb()
        {
        }

        public LearndataContextb(DbContextOptions<LearndataContextb> options)
            : base(options)
        {
        }

        public DbSet<TblCustomer> TblCustomers { get; set; }

        public DbSet<TblUser> TblUsers { get; set; }

        // Add any additional DbSet properties here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings and relationships here
        }
    }
}
