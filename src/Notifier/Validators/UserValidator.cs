using System;
using static Notifier.Helpers.Constants.ErrorMessages.User;

namespace Notifier.Validators
{
    internal static class UserValidator
    {
        private const int MinLength = 5;

        internal static string Validate(this string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException(nameof(user), CannotBeNullOrEmpty);
            }

            if (user.Length < MinLength)
            {
                throw new InvalidOperationException(string.Format(ShouldBeAtLeastNDigitsLong, MinLength));
            }

            return user;
        }
    }
}
