using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Cinema_Manager.Entities
{
    public class Screening
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string MovieTitle { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        [Range(1, 300)]
        public int DurationMinutes { get; set; }

        public DateTime StartTime { get; set; }

        [Range(1, 30)]
        public int HallNumber { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TicketPrice { get; set; }

        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public ICollection<ScreeningCustomer> Customers { get; set; } = new List<ScreeningCustomer>();
    }
}
