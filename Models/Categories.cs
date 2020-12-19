using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Models
{
    public partial class Categories
    {
        public Categories()
        {
            TasksCategories = new HashSet<TasksCategories>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TasksCategories> TasksCategories { get; set; }
    }
}
