using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_Cinema_Manager.Configurations
{
    public class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            builder.HasOne(s => s.Cinema)
                .WithMany(c => c.Screenings)
                .HasForeignKey(s => s.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Screening
                {
                    Id = 1,
                    MovieTitle = "Интерстелар",
                    Genre = "Фантастика",
                    DurationMinutes = 169,
                    StartTime = new DateTime(2026, 12, 5, 19, 0, 0),
                    HallNumber = 1,
                    TicketPrice = 12.50m,
                    CinemaId = 1
                },
                new Screening
                {
                    Id = 2,
                    MovieTitle = "Цар Лъв",
                    Genre = "Анимация",
                    DurationMinutes = 118,
                    StartTime = new DateTime(2026, 12, 6, 11, 0, 0),
                    HallNumber = 2,
                    TicketPrice = 8.00m,
                    CinemaId = 1
                },
                new Screening
                {
                    Id = 3,
                    MovieTitle = "Кръстникът",
                    Genre = "Драма",
                    DurationMinutes = 175,
                    StartTime = new DateTime(2026, 12, 6, 20, 0, 0),
                    HallNumber = 1,
                    TicketPrice = 10.00m,
                    CinemaId = 2
                },
                new Screening
                {
                    Id = 4,
                    MovieTitle = "Матрицата",
                    Genre = "Екшън",
                    DurationMinutes = 136,
                    StartTime = new DateTime(2026, 12, 7, 18, 30, 0),
                    HallNumber = 3,
                    TicketPrice = 11.00m,
                    CinemaId = 3
                },
                new Screening
                {
                    Id = 5,
                    MovieTitle = "Титаник",
                    Genre = "Романтика",
                    DurationMinutes = 195,
                    StartTime = new DateTime(2026, 12, 8, 19, 30, 0),
                    HallNumber = 5,
                    TicketPrice = 12.00m,
                    CinemaId = 3
                }
            );
        }
    }
}
