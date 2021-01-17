using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModel;

namespace TaskManagmentSystem.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            
            CreateMap<Tasks, TasksViewModel>().ReverseMap();
            
            CreateMap<Categories, CategoriesViewModel>().ReverseMap();

            CreateMap<TasksCategories, TasksCategoriesViewModel>().ReverseMap();
           
            CreateMap<Users, UsersViewModel>().ReverseMap();

        }
    }
}
