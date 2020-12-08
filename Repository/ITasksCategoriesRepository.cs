using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
   public interface ITasksCategoriesRepository
    {
        public TasksCategories createTasksCategories(TasksCategories newTasksCategories);
        public TasksCategories delete(int id);
        public TasksCategories getTasksCategoriesById(int id);
        public TasksCategories update(TasksCategories updatedTasksCategories);
        public IEnumerable<TasksCategories> getAllTasksCategories();
    }




    public class TasksCategoriesRepository : ITasksCategoriesRepository
    {

        TaskManagmentSystemContext _context;
        ICategoriesRepository _categoriesRepository;

        public TasksCategoriesRepository(TaskManagmentSystemContext context, ICategoriesRepository categoriesRepository)
        {
            _context = context;
            _categoriesRepository = categoriesRepository;


        }

        public TasksCategories createTasksCategories(TasksCategories newTasksCategories)
        {
            _context.TasksCategories.Add(newTasksCategories);
            _context.SaveChanges();
            return newTasksCategories;
        }

        public TasksCategories delete(int id)
        {
            TasksCategories tasksCategories = _context.TasksCategories.Find(id);

            _categoriesRepository.delete(id);
            _context.TasksCategories.Remove(tasksCategories);
            _context.SaveChanges();
            
            return tasksCategories;
        }

        public IEnumerable<TasksCategories> getAllTasksCategories()
        {
            return _context.TasksCategories;
        }

        public TasksCategories getTasksCategoriesById(int id)
        {
            TasksCategories tasksCategories = _context.TasksCategories.Find(id);
            return tasksCategories;
        }

        public TasksCategories update(TasksCategories updatedTasksCategories)
        {
            var tasksCategories = _context.TasksCategories.Update(updatedTasksCategories);
            _context.SaveChanges();
            return updatedTasksCategories;
        }
    }
}
