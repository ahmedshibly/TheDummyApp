using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDummyApp.Models;

namespace TheDummyApp.Rules.Errors
{
    class ExceptionHeavy
    {

        private readonly UserRepository _userRepository;
        public ExceptionHeavy()
        {
            _userRepository = new UserRepository();
        }

        public User GetUserAsync(string id)
        {
            var user = _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException($"User {id} not found");
            return user;
        }
    }
}
