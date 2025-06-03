namespace TheDummyApp.FPractices.FFailFast.No
{
    // Fail Fast and Early Validation
    internal class BadUserAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BadUserAccountService(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUserAccount(string username, string email, string password)
        {
            var user = new User(username, email); 
            user.SetPassword(password); 
           
            await _userRepository.Add(user); 
            
            await _emailService.SendWelcomeEmail(email, username); 
            
            await _userRepository.SaveChanges();

            return user.Id;
        }
    }
}
