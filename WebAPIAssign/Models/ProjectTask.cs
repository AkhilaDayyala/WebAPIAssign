using System;
using System.Collections.Generic;

namespace WebAPIAssign.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string? Description { get; set; }

        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }
}
