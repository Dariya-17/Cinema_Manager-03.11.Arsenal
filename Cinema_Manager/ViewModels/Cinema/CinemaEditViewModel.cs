using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Cinema
{
    public class CinemaEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително.")]
        public string Name { get; set; }

        [Display(Name = "Град")]
        [Required(ErrorMessage = "Градът е задължителен.")]
        public string City { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адресът е задължителен.")]
        public string Address { get; set; }

        [Display(Name = "Брой зали")]
        [Range(1, 30, ErrorMessage = "Броят зали трябва да е между 1 и 30.")]
        public int HallsCount { get; set; }
    }
}
