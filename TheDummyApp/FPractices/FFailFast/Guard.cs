using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDummyApp.FPractices.FFailFast
{
    public static class Guard
    {
        public static T NotNull<T>(T value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
            return value;
        }

        public static string NotNullOrWhiteSpace(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", paramName);
            return value;
        }

        public static string HasMinLength(string value, int minLength, string paramName)
        {
            NotNull(value, paramName);
            if (value.Length < minLength)
                throw new ArgumentException($"Value must be at least {minLength} characters long.", paramName);
            return value;
        }

        public static string IsValidEmail(string value, string paramName)
        {
            NotNullOrWhiteSpace(value, paramName); 
                                                  
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.", paramName);
            return value;
        }
    }
}
