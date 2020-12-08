using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Models
{
    public partial class TasksCategories
    {
        public int TaskId { get; set; }
        public int CategoryId { get; set; }

        public virtual Tasks Task { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
