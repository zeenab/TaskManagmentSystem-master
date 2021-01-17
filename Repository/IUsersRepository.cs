using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskManagmentSystem.Models;
namespace TaskManagmentSystem.Repository
{
    public interface IUsersRepository
    {
      
        public Users getUsersById(int id);
        public IEnumerable<Users> getAllUsers();
    }




    public class UsersRepository : IUsersRepository
    {
        TaskManagmentSystemContext _context;
       
        public UsersRepository( TaskManagmentSystemContext context)
        {
            _context = context;

        }


        public IEnumerable<Users> getAllUsers()
        { return _context.Users;
        }

        public Users getUsersById(int id)
        {
            Users users = _context.Users.Find(id);
            return users;
        }

    }

}
