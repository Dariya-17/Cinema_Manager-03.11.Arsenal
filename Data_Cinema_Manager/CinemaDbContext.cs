using Data_Cinema_Manager.Configurations;
using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Cinema_Manager
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ScreeningCustomer> ScreeningCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CinemaConfiguration());
            modelBuilder.ApplyConfiguration(new ScreeningConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ScreeningCustomerConfiguration());
        }
    }
}
