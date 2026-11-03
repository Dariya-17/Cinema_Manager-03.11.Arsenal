using System.ComponentModel.DataAnnotations;

namespace Data_Cinema_Manager.Entities
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Range(1, 30)]
        public int HallsCount { get; set; }

        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
