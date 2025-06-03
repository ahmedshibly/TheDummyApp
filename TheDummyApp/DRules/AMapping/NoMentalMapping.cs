namespace TheDummyApp.Rules.Mapping
{
    class NoMentalMapping
    {
        public readonly UserService _userService;
        public NoMentalMapping()
        {
            _userService = new UserService();
        }
        public UserCreationResult HandleUseCreationRequest(UserType userType)
        {           
           var userCreationResult = _userService.CreateUser(userType);          
            return userCreationResult;
        }
    }
}
