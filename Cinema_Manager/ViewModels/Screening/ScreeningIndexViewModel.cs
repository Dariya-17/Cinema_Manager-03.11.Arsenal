using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Screening
{
    public class ScreeningIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Филм")]
        public string MovieTitle { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Начало")]
     
        public DateTime StartTime { get; set; }

        [Display(Name = "Зала")]
        public int HallNumber { get; set; }

        [Display(Name = "Цена")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Кино")]
        public string CinemaName { get; set; }

        [Display(Name = "Брой клиенти")]
        public int CustomersCount { get; set; }
    }
}
