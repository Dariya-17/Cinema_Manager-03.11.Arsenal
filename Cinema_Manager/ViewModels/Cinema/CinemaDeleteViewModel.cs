using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Cinema
{
    public class CinemaDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Град")]
        public string City { get; set; }
    }
}
