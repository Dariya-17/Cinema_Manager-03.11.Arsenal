using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Screening
{
    public class ScreeningDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Филм")]
        public string MovieTitle { get; set; }

        [Display(Name = "Начало")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Кино")]
        public string CinemaName { get; set; }
    }
}
