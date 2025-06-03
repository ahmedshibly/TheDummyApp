namespace TheDummyApp.Rules.Mapping
{
    class MentalMapping
    {
        public readonly UserService _userService;
        public MentalMapping()
        {
            _userService = new UserService();
        }
        public bool HandleRequest(bool flag)
        {

            if (flag) {
                _userService.CreateUser(UserType.System);
            }
            else
            {
                _userService.CreateUser(UserType.Machine);
            }

            return true;
        }
    }
}
