using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            TasksCategories = new HashSet<TasksCategories>();
        }

        public int TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool Complete { get; set; }
        public string Importance { get; set; }

        public virtual ICollection<TasksCategories> TasksCategories { get; set; }
    }
}
