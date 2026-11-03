using Data_Cinema_Manager.Entities;

namespace Cinema_ManagerCore.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> GetCustomerWithScreeningsAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer, List<int> screeningIds);
        Task DeleteCustomerAsync(int id);
    }
}
