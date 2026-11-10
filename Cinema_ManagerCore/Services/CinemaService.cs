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

        public async Task<List<Cinema>> GetAllCinemasAsync(string? search = null, int? minHalls = null, string? sortOrder = null)
        {
            var query = _context.Cinemas
                .Include(c => c.Screenings)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            if (minHalls.HasValue)
            {
                query = query.Where(c => c.HallsCount >= minHalls.Value);
            }

            switch (sortOrder)
            {
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "halls_asc":
                    query = query.OrderBy(c => c.HallsCount);
                    break;
                case "halls_desc":
                    query = query.OrderByDescending(c => c.HallsCount);
                    break;
                default:
                    query = query.OrderBy(c => c.Name);
                    break;
            }

            return await query.ToListAsync();
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
