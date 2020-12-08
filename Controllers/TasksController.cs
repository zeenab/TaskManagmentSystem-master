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
    
    public class TasksController : Controller
    {
        readonly ITasksRepository _tasksRepository;
        readonly IMapper _mapper;

        public TasksController(ITasksRepository tasksRepository , IMapper mapper){
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetAllTasks() {
            //view all Tasks
            var tasks = _tasksRepository.getAllTasks();
            
            return Ok(_mapper.Map<IEnumerable<TasksViewModel>>(tasks));
        }

        [HttpGet]
         public IActionResult GetTask(int id) {
            //view specific Task by id
            var tasks = _tasksRepository.getTasksById(id);
             return Ok(_mapper.Map<TasksViewModel>(tasks));

         }

        [HttpPost]
        public IActionResult Create([FromBody]TasksViewModel newTasks) {
            //[FromBody]-> because the task attributes declaring in body in the postman
           
            var tasks = _mapper.Map<Tasks>(newTasks);  //it will map object from TaskView into Tasks 
            _tasksRepository.createTasks(tasks);
            return Ok(tasks);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            //to delete specific task by id
            var tasks = _tasksRepository.getTasksById(id);
            if (tasks == null) return NotFound();
            _tasksRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody]TasksViewModel updatedTasks) {
            //to update any attribute in task by id
            var tasks = _tasksRepository.getTasksById(updatedTasks.TaskId);
            if (tasks == null) return NotFound();
            _tasksRepository.update(_mapper.Map(updatedTasks, tasks));
            return Ok(_mapper.Map<TasksViewModel>(tasks));
        }
   
 
    
    }
}
