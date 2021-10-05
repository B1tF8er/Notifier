using System;
using static Notifier.Helpers.Constants.ErrorMessages.Password;

namespace Notifier.Validators
{
    internal static class PasswordValidator
    {
        private const int MinLength = 10;

        internal static string Validate(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), CannotBeNullOrEmpty);
            }

            if (password.Length < MinLength)
            {
                throw new InvalidOperationException(string.Format(ShouldBeAtLeastNDigitsLong, MinLength));
            }

            return password;
        }
    }
}
