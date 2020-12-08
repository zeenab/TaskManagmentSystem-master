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
    public class CategoriesController : Controller
    {

        readonly ICategoriesRepository _categoriesRepository;
        readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            //view all Categories
            var categories = _categoriesRepository.getAllCategories();

            return Ok(_mapper.Map<IEnumerable<CategoriesViewModel>>(categories));
        }

        [HttpGet]
        public IActionResult GetCategories(int id)
        {
            //view specific category by id
            var categories = _categoriesRepository.getCategoriesById(id);
            return Ok(_mapper.Map<CategoriesViewModel>(categories));

        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoriesViewModel newCategory)
        {
            //[FromBody]-> because the Categories attributes declaring in body in the postman

            var categories = _mapper.Map<Categories>(newCategory);  //it will map object from CategoryView into Categories 
            _categoriesRepository.createCategories(categories);
            return Ok(categories);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //to delete specific category by id
            var categories = _categoriesRepository.getCategoriesById(id);
            if (categories == null) return NotFound();
            _categoriesRepository.delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] CategoriesViewModel updatedCategory)
        {
            //to update any attribute in category by id
            var categories = _categoriesRepository.getCategoriesById(updatedCategory.CategoryId);
            if (categories == null) return NotFound();
            _categoriesRepository.update(_mapper.Map(updatedCategory, categories));
;            return Ok(_mapper.Map<CategoriesViewModel>(categories));
        }




    }
}
