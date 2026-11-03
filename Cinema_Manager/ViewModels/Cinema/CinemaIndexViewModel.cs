using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Cinema
{
    public class CinemaIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Град")]
        public string City { get; set; }

        [Display(Name = "Брой зали")]
        public int HallsCount { get; set; }

        [Display(Name = "Брой прожекции")]
        public int ScreeningsCount { get; set; }
    }
}
