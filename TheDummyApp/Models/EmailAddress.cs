using System.ComponentModel.DataAnnotations;

namespace TheDummyApp.Models
{
    public readonly record struct EmailAddress
    {
        private readonly string _value;

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidEmail(value))
                throw new ArgumentException("Invalid email format");
            _value = value;
        }

        public static implicit operator string(EmailAddress email) => email._value;
        private static bool IsValidEmail(string email) =>
            new EmailAddressAttribute().IsValid(email);
    }

}
