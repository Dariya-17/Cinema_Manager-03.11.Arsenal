using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager;
using Data_Cinema_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagerCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CinemaDbContext _context;

        public CustomerService(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Screenings)
                .ThenInclude(sc => sc.Screening)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomerWithScreeningsAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Screenings)
                .ThenInclude(sc => sc.Screening)
                .ThenInclude(s => s.Cinema)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer, List<int> screeningIds)
        {
            var newIds = screeningIds.Distinct().ToList();

            var toRemove = customer.Screenings
                .Where(sc => !newIds.Contains(sc.ScreeningId))
                .ToList();

            _context.ScreeningCustomers.RemoveRange(toRemove);

      
            var existingIds = customer.Screenings.Select(sc => sc.ScreeningId).ToList();

            foreach (var screeningId in newIds.Where(id => !existingIds.Contains(id)))
            {
                customer.Screenings.Add(new ScreeningCustomer
                {
                    ScreeningId = screeningId,
                    CustomerId = customer.Id
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Screenings)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer != null)
            {
                _context.ScreeningCustomers.RemoveRange(customer.Screenings);
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
