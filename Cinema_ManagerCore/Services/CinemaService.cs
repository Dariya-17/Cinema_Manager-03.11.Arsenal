using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager;
using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagerCore.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext _context;

        public CinemaService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cinema>> GetAllCinemasAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Screenings)
                .ToListAsync();
        }

        public async Task<Cinema> GetCinemaByIdAsync(int id)
        {
            return await _context.Cinemas.FindAsync(id);
        }

        public async Task<Cinema> GetCinemaDetailsAsync(int id)
        {
            return await _context.Cinemas
                .Include(c => c.Screenings)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCinemaAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCinemaAsync(Cinema cinema)
        {
           
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCinemaAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
            }
        }
    }
}
