using Data_Cinema_Manager.Entities;

namespace Cinema_ManagerCore.Interfaces
{
    public interface IScreeningService
    {
        Task<List<Screening>> GetAllScreeningsAsync();
        Task<Screening> GetScreeningByIdAsync(int id);
        Task<Screening> GetScreeningDetailsAsync(int id);
        Task AddScreeningAsync(Screening screening);
        Task UpdateScreeningAsync(Screening screening);
        Task DeleteScreeningAsync(int id);
        Task<bool> HallExistsAsync(int cinemaId, int hallNumber);
        Task<bool> IsHallBusyAsync(int cinemaId, int hallNumber, DateTime startTime, int durationMinutes, int currentId);
    }
}
