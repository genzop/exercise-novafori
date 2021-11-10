using System.ComponentModel.DataAnnotations;

namespace PerfectChannel.WebApi.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Pending,
        Completed
    }
}
