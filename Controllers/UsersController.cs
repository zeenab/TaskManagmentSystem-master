using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.ViewModel;

namespace TaskManagmentSystem.Controllers
{
    public class UsersController : Controller
    {
        readonly IUsersRepository _userssRepository;
        readonly IMapper _mapper;

        public UsersController(IUsersRepository userssRepository, IMapper mapper)
        {
            _userssRepository = userssRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            //view all Tasks Categories
            var users = _userssRepository.getAllUsers();
            return Ok(_mapper.Map<IEnumerable<UsersViewModel>>(users));
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            //view specific Task category by id
            var users = _userssRepository.getUsersById(id);
            return Ok(_mapper.Map<UsersViewModel>(users));


        }

    }
}
