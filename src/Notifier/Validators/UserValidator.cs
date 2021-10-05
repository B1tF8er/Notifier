using System;

namespace Notifier.Validators
{
    internal static class UserValidator
    {
        private const int MinLength = 5;

        internal static string Validate(this string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null or empty");
            }

            if (user.Length < MinLength)
            {
                throw new InvalidOperationException($"User should be at least {MinLength} digits long");
            }

            return user;
        }
    }
}
