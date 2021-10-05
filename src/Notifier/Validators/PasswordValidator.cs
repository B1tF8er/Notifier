using System;

namespace Notifier.Validators
{
    internal static class PasswordValidator
    {
        private const int MinLength = 10;

        internal static string Validate(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null or empty");
            }

            if (password.Length < MinLength)
            {
                throw new InvalidOperationException($"Password should be at least {MinLength} digits long");
            }

            return password;
        }
    }
}
