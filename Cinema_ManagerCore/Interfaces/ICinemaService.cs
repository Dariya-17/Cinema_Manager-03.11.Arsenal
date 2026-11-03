using Data_Cinema_Manager.Entities;

namespace Cinema_ManagerCore.Interfaces
{
    public interface ICinemaService
    {
        Task<List<Cinema>> GetAllCinemasAsync();
        Task<Cinema> GetCinemaByIdAsync(int id);
        Task<Cinema> GetCinemaDetailsAsync(int id);
        Task AddCinemaAsync(Cinema cinema);
        Task UpdateCinemaAsync(Cinema cinema);
        Task DeleteCinemaAsync(int id);
    }
}
