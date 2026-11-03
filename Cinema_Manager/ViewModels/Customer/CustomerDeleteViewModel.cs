using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Customer
{
    public class CustomerDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}
