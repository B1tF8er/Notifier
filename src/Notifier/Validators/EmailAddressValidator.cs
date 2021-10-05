using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;

namespace Notifier.Validators
{
    internal static class EmailAddressValidator
    {
        internal static string Validate(this string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress), "Email address cannot be null");
            }

            var match = Regex.Match(
                emailAddress,
                EmailRegex,
                RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            if (!match.Success)
            {
                throw new FormatException("Invalid email address format");
            }

            return emailAddress;
        }
    }
}
