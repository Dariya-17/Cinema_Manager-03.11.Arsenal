using Cinema_Manager.ViewModels.Customer;
using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema_Manager.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IScreeningService _screeningService;

        public CustomerController(ICustomerService customerService, IScreeningService screeningService)
        {
            _customerService = customerService;
            _screeningService = screeningService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            var model = new List<CustomerIndexViewModel>();

            foreach (var item in customers)
            {
                model.Add(new CustomerIndexViewModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    ScreeningNames = string.Join(", ", item.Screenings.Select(sc => sc.Screening.MovieTitle))
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.GetCustomerWithScreeningsAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var model = new CustomerDetailsViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,

                Screenings = customer.Screenings
                    .OrderBy(sc => sc.Screening.StartTime)
                    .Select(sc => new CustomerScreeningViewModel
                    {
                        Id = sc.ScreeningId,
                        MovieTitle = sc.Screening.MovieTitle,
                        CinemaName = sc.Screening.Cinema.Name,
                        StartTime = sc.Screening.StartTime,
                        HallNumber = sc.Screening.HallNumber
                    })
                    .ToList()
            };

            return View(model);
        }

        private async Task LoadScreenings(List<int> selectedScreenings = null)
        {
            var screenings = (await _screeningService.GetAllScreeningsAsync())
                .Select(s => new
                {
                    s.Id,
                    FullName = s.MovieTitle + " - " + s.Cinema.Name + " (" + s.StartTime.ToString("dd.MM.yyyy HH:mm") + ")"
                })
                .ToList();

            ViewBag.Screenings = new MultiSelectList(screenings, "Id", "FullName", selectedScreenings);
        }

        public async Task<IActionResult> Create()
        {
            await LoadScreenings();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                foreach (var screeningId in model.ScreeningIds.Distinct())
                {
                    customer.Screenings.Add(new ScreeningCustomer
                    {
                     
                        ScreeningId = screeningId
                    });
                }

                await _customerService.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }

            await LoadScreenings(model.ScreeningIds);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerWithScreeningsAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var model = new CustomerEditViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                ScreeningIds = customer.Screenings.Select(sc => sc.ScreeningId).ToList()
            };

            await LoadScreenings(model.ScreeningIds);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var customer = await _customerService.GetCustomerWithScreeningsAsync(id);

                if (customer == null)
                {
                    return NotFound();
                }

                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Email = model.Email;
                customer.PhoneNumber = model.PhoneNumber;

           
                await _customerService.UpdateCustomerAsync(customer, model.ScreeningIds);
                return RedirectToAction(nameof(Index));
            }

            await LoadScreenings(model.ScreeningIds);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var model = new CustomerDeleteViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
