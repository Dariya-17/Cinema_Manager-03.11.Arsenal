using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Cinema_Manager.Configurations
{
    public class ScreeningCustomerConfiguration : IEntityTypeConfiguration<ScreeningCustomer>
    {
        public void Configure(EntityTypeBuilder<ScreeningCustomer> builder)
        {
        
            builder.HasKey(sc => new { sc.ScreeningId, sc.CustomerId });

            builder.HasOne(sc => sc.Screening)
                .WithMany(s => s.Customers)
                .HasForeignKey(sc => sc.ScreeningId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Customer)
                .WithMany(c => c.Screenings)
                .HasForeignKey(sc => sc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ScreeningCustomer { ScreeningId = 1, CustomerId = 1 },
                new ScreeningCustomer { ScreeningId = 1, CustomerId = 2 },
                new ScreeningCustomer { ScreeningId = 2, CustomerId = 1 },
                new ScreeningCustomer { ScreeningId = 2, CustomerId = 3 },
                new ScreeningCustomer { ScreeningId = 3, CustomerId = 4 },
                new ScreeningCustomer { ScreeningId = 4, CustomerId = 5 },
                new ScreeningCustomer { ScreeningId = 5, CustomerId = 3 }
            );
        }
    }
}
