using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModel;

namespace TaskManagmentSystem.Controllers
{
    public class TasksCategoriesController : Controller
    {


        readonly ITasksCategoriesRepository _tasksCategoriesRepository;
        readonly IMapper _mapper;

        public TasksCategoriesController(ITasksCategoriesRepository taskCategoriesRepository, IMapper mapper)
        {
            _tasksCategoriesRepository = taskCategoriesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllTasksCategories()
        {
            //view all Tasks Categories
            var tasksCategories = _tasksCategoriesRepository.getAllTasksCategories();

            return Ok(_mapper.Map<IEnumerable<TasksCategoriesViewModel>>(tasksCategories));
        }

        [HttpGet]
        public IActionResult GetTasksCategories(int id)
        {
            //view specific Task category by id
            var tasksCategories = _tasksCategoriesRepository.getTasksCategoriesById(id);
            return Ok(_mapper.Map<TasksCategoriesViewModel>(tasksCategories));

        }

        [HttpPost]
        public IActionResult Create([FromBody] TasksCategoriesViewModel newTasksCategories)
        {
            //[FromBody]-> because the task category attributes declaring in body in the postman

            var tasksCategories = _mapper.Map<TasksCategories>(newTasksCategories);  //it will map object from TaskCategoryView into TasksCategories 
            _tasksCategoriesRepository.createTasksCategories(tasksCategories);
            return Ok(tasksCategories);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //to delete specific task category by id
            var tasksCategories = _tasksCategoriesRepository.getTasksCategoriesById(id);
            if (tasksCategories == null) return NotFound();
            _tasksCategoriesRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] TasksCategoriesViewModel updatedTasksCategories)
        {
            //to update any attribute in task category by id
            var tasksCategories = _tasksCategoriesRepository.getTasksCategoriesById(updatedTasksCategories.CategoryId);
            if (tasksCategories == null) return NotFound();
            _tasksCategoriesRepository.update(_mapper.Map(updatedTasksCategories, tasksCategories));
            return Ok(_mapper.Map<TasksCategoriesViewModel>(tasksCategories));
        }





    }
}
