using System.ComponentModel.DataAnnotations;

namespace Cinema_Manager.ViewModels.Customer
{
    public class CustomerEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(30, ErrorMessage = "Името не може да бъде по-дълго от 30 символа.")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилията е задължителна.")]
        [MaxLength(30, ErrorMessage = "Фамилията не може да бъде по-дълга от 30 символа.")]
        public string LastName { get; set; }

        [Display(Name = "Имейл")]
        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Моля, въведете валиден имейл адрес.")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Телефонният номер е задължителен.")]
        [Phone(ErrorMessage = "Моля, въведете валиден телефонен номер.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Прожекции")]
        [Required(ErrorMessage = "Моля, изберете поне една прожекция.")]
        public List<int> ScreeningIds { get; set; }
    }
}
