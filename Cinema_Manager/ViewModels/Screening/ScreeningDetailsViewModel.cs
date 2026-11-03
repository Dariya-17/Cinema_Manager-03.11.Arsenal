using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Screening
{
    public class ScreeningDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Филм")]
        public string MovieTitle { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Продължителност")]
  
        public int DurationMinutes { get; set; }

        [Display(Name = "Начало")]

        public DateTime StartTime { get; set; }

        [Display(Name = "Зала")]
        public int HallNumber { get; set; }

        [Display(Name = "Цена")]

        public decimal TicketPrice { get; set; }

        [Display(Name = "Кино")]
        public string CinemaName { get; set; }

        [Display(Name = "Град")]
        public string CinemaCity { get; set; }

        [Display(Name = "Адрес")]
        public string CinemaAddress { get; set; }

        [Display(Name = "Клиенти")]
        public List<string> Customers { get; set; } = new List<string>();
    }
}
