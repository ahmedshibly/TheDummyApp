using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDummyApp.FPractices.FFailFast.No
{
    internal class BetterUserAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BetterUserAccountService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<Guid> CreateUserAccount(string username, string email, string password)
        {
            // 1. Basic Input Validation (Early Validation)
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty.", nameof(username));
            }
            if (username.Length < 3)
            {
                throw new ArgumentException("Username must be at least 3 characters long.", nameof(username));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            }


            // Simple email regex for illustration. Use a robust library for production.
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(password));
            }
            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.", nameof(password));
            }

            // 2. Business Rule Validation (Early Validation)
            if (await _userRepository.ExistsByUsername(username))
            {
                throw new InvalidOperationException($"Username '{username}' already exists.");
            }
            if (await _userRepository.ExistsByEmail(email))
            {
                throw new InvalidOperationException($"Email '{email}' is already registered.");
            }

            // 3. Only now, proceed with core logic and external calls
            var user = new User(username, email); // Now we know username/email are valid format
            user.SetPassword(password);           // Now we know password is valid length

            await _userRepository.Add(user);
            await _userRepository.SaveChanges();

            await _emailService.SendWelcomeEmail(email, username);

            return user.Id;
        }
    }
}
