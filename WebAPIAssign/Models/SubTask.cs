using System;

namespace WebAPIAssign.Models
{
    public class SubTask
    {
        public int Id { get; set; }

        public string SubTaskName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; } = string.Empty;

        public int TaskId { get; set; } // Changed to int to match ProjectTask's Id type

        public ProjectTask Tasks { get; set; } = null!;
    }
}
