using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDummyApp.Models;

namespace TheDummyApp
{

    public class UserCreationResult
    {

    }

    public class UserService
    {
        public IList<User> Users = [];
        public UserCreationResult CreateUser(UserType type)
        {
            User user = new User();
            Users.Add(user);

            return new UserCreationResult();
        }
    }


    public class UserRepository
    {
        public IList<User> Users = [ new User { }];
        public User GetByIdAsync(string id)
        {
            return Users.First();
        }
    }
}
