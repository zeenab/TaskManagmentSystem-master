﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public interface ITasksRepository
    {
        public Tasks createTasks(Tasks newTask);
        public Tasks delete(int id);
        public Tasks getTasksById(int id);
        public Tasks update(Tasks updatedTask);
        public IEnumerable<Tasks> getAllTasks();
        
    }





    public class TasksRepository : ITasksRepository
    {
        TaskManagmentSystemContext _context;
        private readonly IConfiguration _configuration;
        public TasksRepository(IConfiguration configuration,TaskManagmentSystemContext context)
        {
            _configuration = configuration;
            _context = context;
          
        }

        public Tasks createTasks(Tasks newTasks)
        {
            _context.Tasks.Add(newTasks);
            _context.SaveChanges();
            return newTasks;
        }

        
        public Tasks delete(int id)
        {
            Tasks tasks = _context.Tasks.Find(id);
            //  String sql=" delete from TasksCategories where TaskId=id";
            // _context.Database.ExecuteSqlCommand(sql);


            string query = @"delete from TasksCategories where TaskId=" + id + @"";
       
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentSystemContext");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }






            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
            return tasks;
        }

        public IEnumerable<Tasks> getAllTasks()
        {
            return _context.Tasks;
        }

        public Tasks getTasksById(int id)
        {
            Tasks tasks = _context.Tasks.Find(id);
            return tasks;
        }

        public Tasks update(Tasks updatedTasks)
        {
            _context.Tasks.Update(updatedTasks);
            _context.SaveChanges();
            return updatedTasks;
        }

        
    }
}
