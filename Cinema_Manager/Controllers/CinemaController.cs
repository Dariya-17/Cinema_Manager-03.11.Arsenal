using Cinema_Manager.ViewModels.Cinema;
using Cinema_ManagerCore.Interfaces;
using Data_Cinema_Manager.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Manager.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllCinemasAsync();

            var model = new List<CinemaIndexViewModel>();

            foreach (var cinema in cinemas)
            {
                model.Add(new CinemaIndexViewModel
                {
                    Id = cinema.Id,
                    Name = cinema.Name,
                    City = cinema.City,
                    HallsCount = cinema.HallsCount,
                    ScreeningsCount = cinema.Screenings.Count
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetCinemaDetailsAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }

            var model = new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                City = cinema.City,
                Address = cinema.Address,
                HallsCount = cinema.HallsCount
            };

            foreach (var screening in cinema.Screenings.OrderBy(s => s.StartTime))
            {
                model.Screenings.Add(new CinemaScreeningViewModel
                {
                    Id = screening.Id,
                    MovieTitle = screening.MovieTitle,
                    Genre = screening.Genre,
                    StartTime = screening.StartTime,
                    HallNumber = screening.HallNumber
                });
            }

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CinemaCreateViewModel
            {
                HallsCount = 1
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cinema = new Cinema
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                    HallsCount = model.HallsCount
                };

                await _cinemaService.AddCinemaAsync(cinema);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetCinemaByIdAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }

            var model = new CinemaEditViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                City = cinema.City,
                Address = cinema.Address,
                HallsCount = cinema.HallsCount
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CinemaEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cinema = await _cinemaService.GetCinemaByIdAsync(id);

                if (cinema == null)
                {
                    return NotFound();
                }

                cinema.Name = model.Name;
                cinema.City = model.City;
                cinema.Address = model.Address;
                cinema.HallsCount = model.HallsCount;

                await _cinemaService.UpdateCinemaAsync(cinema);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetCinemaByIdAsync(id);

            if (cinema == null)
            {
                return NotFound();
            }

            var model = new CinemaDeleteViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                City = cinema.City
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cinemaService.DeleteCinemaAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
