using System.ComponentModel.DataAnnotations;

namespace Data_Cinema_Manager.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<ScreeningCustomer> Screenings { get; set; } = new List<ScreeningCustomer>();
    }
}
