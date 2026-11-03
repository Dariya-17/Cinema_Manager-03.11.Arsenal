using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Cinema
{
    public class CinemaDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Град")]
        public string City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Брой зали")]
        public int HallsCount { get; set; }

        public List<CinemaScreeningViewModel> Screenings { get; set; } = new List<CinemaScreeningViewModel>();
    }

    public class CinemaScreeningViewModel
    {
        public int Id { get; set; }

        public string MovieTitle { get; set; }

        public string Genre { get; set; }

        public DateTime StartTime { get; set; }

        public int HallNumber { get; set; }
    }
}
