using Cinema_Manager.ViewModels.Screening;
using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema_Manager.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningService _screeningService;
        private readonly ICinemaService _cinemaService;

        public ScreeningController(IScreeningService screeningService, ICinemaService cinemaService)
        {
            _screeningService = screeningService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var screenings = await _screeningService.GetAllScreeningsAsync();

            var model = new List<ScreeningIndexViewModel>();

            foreach (var screening in screenings)
            {
                model.Add(new ScreeningIndexViewModel
                {
                    Id = screening.Id,
                    MovieTitle = screening.MovieTitle,
                    Genre = screening.Genre,
                    StartTime = screening.StartTime,
                    HallNumber = screening.HallNumber,
                    TicketPrice = screening.TicketPrice,
                    CinemaName = screening.Cinema.Name,
                    CustomersCount = screening.Customers.Count
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var screening = await _screeningService.GetScreeningDetailsAsync(id);

            if (screening == null)
            {
                return NotFound();
            }

            var model = new ScreeningDetailsViewModel
            {
                Id = screening.Id,
                MovieTitle = screening.MovieTitle,
                Genre = screening.Genre,
                DurationMinutes = screening.DurationMinutes,
                StartTime = screening.StartTime,
                HallNumber = screening.HallNumber,
                TicketPrice = screening.TicketPrice,
                CinemaName = screening.Cinema.Name,
                CinemaCity = screening.Cinema.City,
                CinemaAddress = screening.Cinema.Address,

                Customers = screening.Customers
                    .Select(sc => sc.Customer.FirstName + " " + sc.Customer.LastName)
                    .ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCinemas();

            var model = new ScreeningCreateViewModel
            {
                StartTime = DateTime.Today.AddDays(1).AddHours(19),
                DurationMinutes = 120,
                HallNumber = 1,
                TicketPrice = 10
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScreeningCreateViewModel model)
        {
            if (model.StartTime < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.StartTime), "Датата не може да е по-стара от днес.");
            }

            await CheckHallAndTime(model.CinemaId, model.HallNumber, model.StartTime, model.DurationMinutes, 0);

            if (ModelState.IsValid)
            {
                var screening = new Screening
                {
                    MovieTitle = model.MovieTitle,
                    Genre = model.Genre,
                    DurationMinutes = model.DurationMinutes,
                    StartTime = model.StartTime,
                    HallNumber = model.HallNumber,
                    TicketPrice = model.TicketPrice,
                    CinemaId = model.CinemaId
                };

                await _screeningService.AddScreeningAsync(screening);

                return RedirectToAction(nameof(Index));
            }

            await LoadCinemas(model.CinemaId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var screening = await _screeningService.GetScreeningByIdAsync(id);

            if (screening == null)
            {
                return NotFound();
            }

            var model = new ScreeningEditViewModel
            {
                Id = screening.Id,
                MovieTitle = screening.MovieTitle,
                Genre = screening.Genre,
                DurationMinutes = screening.DurationMinutes,
                StartTime = screening.StartTime,
                HallNumber = screening.HallNumber,
                TicketPrice = screening.TicketPrice,
                CinemaId = screening.CinemaId
            };

            await LoadCinemas(model.CinemaId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ScreeningEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (model.StartTime < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.StartTime), "Датата не може да е по-стара от днес.");
            }

            await CheckHallAndTime(model.CinemaId, model.HallNumber, model.StartTime, model.DurationMinutes, model.Id);

            if (ModelState.IsValid)
            {
                var screening = await _screeningService.GetScreeningByIdAsync(id);

                if (screening == null)
                {
                    return NotFound();
                }

                screening.MovieTitle = model.MovieTitle;
                screening.Genre = model.Genre;
                screening.DurationMinutes = model.DurationMinutes;
                screening.StartTime = model.StartTime;
                screening.HallNumber = model.HallNumber;
                screening.TicketPrice = model.TicketPrice;
                screening.CinemaId = model.CinemaId;

                await _screeningService.UpdateScreeningAsync(screening);

                return RedirectToAction(nameof(Index));
            }

            await LoadCinemas(model.CinemaId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var screening = await _screeningService.GetScreeningDetailsAsync(id);

            if (screening == null)
            {
                return NotFound();
            }

            var model = new ScreeningDeleteViewModel
            {
                Id = screening.Id,
                MovieTitle = screening.MovieTitle,
                StartTime = screening.StartTime,
                CinemaName = screening.Cinema.Name
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _screeningService.DeleteScreeningAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task CheckHallAndTime(int cinemaId, int hallNumber, DateTime startTime, int durationMinutes, int currentId)
        {
            var cinema = await _cinemaService.GetCinemaByIdAsync(cinemaId);

            if (cinema == null)
            {
                return;
            }

            if (!await _screeningService.HallExistsAsync(cinemaId, hallNumber))
            {
                ModelState.AddModelError("HallNumber", "Това кино няма такава зала");
                return;
            }

            if (await _screeningService.IsHallBusyAsync(cinemaId, hallNumber, startTime, durationMinutes, currentId))
            {
                ModelState.AddModelError("StartTime", "Залата е заета по това време");
            }
        }

        private async Task LoadCinemas(int? selectedCinemaId = null)
        {
            var cinemas = await _cinemaService.GetAllCinemasAsync();
            ViewBag.Cinemas = new SelectList(cinemas, "Id", "Name", selectedCinemaId);
        }
    }
}
