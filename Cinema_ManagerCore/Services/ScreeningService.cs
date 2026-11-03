using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager;
using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagerCore.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly CinemaDbContext _context;

        public ScreeningService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Screening>> GetAllScreeningsAsync()
        {
            return await _context.Screenings
                .Include(s => s.Cinema)
                .Include(s => s.Customers)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<Screening> GetScreeningByIdAsync(int id)
        {
            return await _context.Screenings.FindAsync(id);
        }

        public async Task<Screening> GetScreeningDetailsAsync(int id)
        {
            return await _context.Screenings
                .Include(s => s.Cinema)
                .Include(s => s.Customers)
                .ThenInclude(sc => sc.Customer)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddScreeningAsync(Screening screening)
        {
            await _context.Screenings.AddAsync(screening);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScreeningAsync(Screening screening)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScreeningAsync(int id)
        {
            var screening = await _context.Screenings
                .Include(s => s.Customers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (screening != null)
            {
                _context.ScreeningCustomers.RemoveRange(screening.Customers);
                _context.Screenings.Remove(screening);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> HallExistsAsync(int cinemaId, int hallNumber)
        {
            var cinema = await _context.Cinemas.FindAsync(cinemaId);

            if (cinema == null)
            {
                return false;
            }

            return hallNumber <= cinema.HallsCount;
        }

        public async Task<bool> IsHallBusyAsync(int cinemaId, int hallNumber, DateTime startTime, int durationMinutes, int currentId)
        {
            var endTime = startTime.AddMinutes(durationMinutes);

            var screenings = await _context.Screenings
                .Where(s => s.CinemaId == cinemaId && s.HallNumber == hallNumber && s.Id != currentId)
                .ToListAsync();

            foreach (var screening in screenings)
            {
                var screeningEnd = screening.StartTime.AddMinutes(screening.DurationMinutes);

                if (startTime < screeningEnd && screening.StartTime < endTime)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
