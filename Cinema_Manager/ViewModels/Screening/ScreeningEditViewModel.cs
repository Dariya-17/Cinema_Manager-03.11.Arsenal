using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Screening
{
    public class ScreeningEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Филм")]
        [Required(ErrorMessage = "Заглавието е задължително.")]

        public string MovieTitle { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Жанрът е задължителен.")]

        public string Genre { get; set; }

        [Display(Name = "Продължителност (мин.)")]
        [Range(1, 300, ErrorMessage = "Продължителността трябва да е между 1 и 300 минути.")]
        public int DurationMinutes { get; set; }

        [Display(Name = "Начало")]
        [Required(ErrorMessage = "Датата и часът са задължителни.")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Зала")]
        [Range(1, 30, ErrorMessage = "Залата трябва да е между 1 и 30.")]
        public int HallNumber { get; set; }

        [Display(Name = "Цена (€)")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Кино")]
        [Required(ErrorMessage = "Моля, изберете кино.")]
        public int CinemaId { get; set; }
    }
}
