using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Customer
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        public List<CustomerScreeningViewModel> Screenings { get; set; } = new List<CustomerScreeningViewModel>();
    }

    public class CustomerScreeningViewModel
    {
        public int Id { get; set; }

        public string MovieTitle { get; set; }

        public string CinemaName { get; set; }

        public DateTime StartTime { get; set; }

        public int HallNumber { get; set; }
    }
}
