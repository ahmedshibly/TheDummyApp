using Ardalis.Result;
using TheDummyApp.Models;

namespace TheDummyApp.Rules.Errors
{
    class ResultPattern
    {
        private readonly UserRepository _userRepository;
        public ResultPattern()
        {
            _userRepository = new UserRepository();
        }
        public Result<User> GetUserAsync(string id)
        {
            var user = _userRepository.GetByIdAsync(id);
            return user is null
                ? Result<User>.Error($"User {id} not found")
                : Result<User>.Success(user);
        }

        //have a look at 
        //https://github.com/ardalis/Result

        //Or 
        //var response = await GetUserAsync(userId);
        //return response.Match(
        //    onSuccess: user => Ok(user),
        //    onFailure: error => BadRequest(error)
        //);
    }
}
