using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Customer
{
    public class CustomerIndexViewModel
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

        [Display(Name = "Прожекции")]
        public string ScreeningNames { get; set; } = string.Empty;
    }
}
