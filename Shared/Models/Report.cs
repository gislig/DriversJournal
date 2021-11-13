using System.ComponentModel.DataAnnotations;

namespace DrivingJournal.Shared.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Driver Driver { get; set; }
        public Car Car { get; set; }
    }
}
