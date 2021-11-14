using System.ComponentModel.DataAnnotations;

namespace DrivingJournal.Shared.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PlateNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
