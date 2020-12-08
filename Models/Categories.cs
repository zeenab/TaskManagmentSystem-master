using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Models
{
    public partial class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual TasksCategories Category { get; set; }
    }
}
