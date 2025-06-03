using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDummyApp.FPractices.FFailFast.Services
{
    internal class ExcellentUserAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ExcellentUserAccountService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<Guid> CreateUserAccount(string username, string email, string password)
        {

            Guard.NotNullOrWhiteSpace(username, nameof(username));
            Guard.HasMinLength(username, 3, nameof(username));


            //NOTE: For Pro Max UserAccountService We can implement validators here
            Guard.IsValidEmail(email, nameof(email));
            Guard.HasMinLength(password, 8, nameof(password));

            if (await _userRepository.ExistsByUsername(username))
            {
                throw new InvalidOperationException($"Username '{username}' already exists.");
            }
            if (await _userRepository.ExistsByEmail(email))
            {
                throw new InvalidOperationException($"Email '{email}' is already registered.");
            }


            var user = new User(username, email);
            user.SetPassword(password);

            await _userRepository.Add(user);
            await _userRepository.SaveChanges();

            await _emailService.SendWelcomeEmail(email, username);

            return user.Id;
        }
    }
}