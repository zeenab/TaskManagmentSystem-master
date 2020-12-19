using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;

namespace TaskManagmentSystem.Repository
{
    public interface ICategoriesRepository
    {
        public Categories createCategories(Categories newCategories);
        public Categories delete(int id);
        public Categories getCategoriesById(int id);
        public Categories update(Categories updatedTask);
        public IEnumerable<Categories> getAllCategories();
    }



    public class CategoriesRepository : ICategoriesRepository
    {
        TaskManagmentSystemContext _context;

        private readonly IConfiguration _configuration;
        public CategoriesRepository(IConfiguration configuration,TaskManagmentSystemContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Categories createCategories(Categories newCategories)
        {
            _context.Categories.Add(newCategories);
            _context.SaveChanges();
            return newCategories;
        }

        public Categories delete(int id)
        {
            Categories categories = _context.Categories.Find(id);



            string query = @"delete from TasksCategories where CategoryId=" + id + @"";

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





            _context.Categories.Remove(categories);
                _context.SaveChanges();
            return categories;
        }

        public IEnumerable<Categories> getAllCategories()
        {
            return _context.Categories;
        }

        public Categories getCategoriesById(int id)
        {
            Categories categories = _context.Categories.Find(id);
            return categories;
        }

        public Categories update(Categories updatedCategories)
        {
            _context.Categories.Update(updatedCategories);
            _context.SaveChanges();
            return updatedCategories;
        }
    }

}
