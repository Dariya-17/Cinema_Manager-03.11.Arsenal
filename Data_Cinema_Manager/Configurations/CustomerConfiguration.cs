using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Cinema_Manager.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Петър",
                    LastName = "Стоянов",
                    Email = "petar.stoyanov@email.com",
                    PhoneNumber = "0899111222"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Николина",
                    LastName = "Колева",
                    Email = "nikolina.koleva@email.com",
                    PhoneNumber = "0899222333"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Стефан",
                    LastName = "Тодоров",
                    Email = "stefan.todorov@email.com",
                    PhoneNumber = "0899333444"
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Десислава",
                    LastName = "Николова",
                    Email = "desislava.nikolova@email.com",
                    PhoneNumber = "0899444555"
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Христо",
                    LastName = "Ангелов",
                    Email = "hristo.angelov@email.com",
                    PhoneNumber = "0899555666"
                }
            );
        }
    }
}
