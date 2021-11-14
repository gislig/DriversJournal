using System.ComponentModel.DataAnnotations;

namespace DrivingJournal.Shared.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Oid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
