using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Cinema_Manager.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(
                new Cinema
                {
                    Id = 1,
                    Name = "Cinema City",
                    City = "Стара Загора",
                    Address = "бул. Никола Петков 52",
                    HallsCount = 6
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Кино Арена",
                    City = "Казанлък",
                    Address = "ул. Искра 10",
                    HallsCount = 3
                },
                new Cinema
                {
                    Id = 3,
                    Name = "Кино Лъки",
                    City = "Пловдив",
                    Address = "бул. Христо Ботев 82",
                    HallsCount = 8
                }
            );
        }
    }
}
