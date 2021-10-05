using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;

namespace Notifier.Validators
{
    internal static class CellphoneNumberValidator
    {
        private const int MinLength = 10;

        internal static string Validate(this string cellPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(cellPhoneNumber))
            {
                throw new ArgumentNullException(nameof(cellPhoneNumber), "Cell phone number cannot be null");
            }

            if (cellPhoneNumber.Length < MinLength)
            {
                throw new InvalidOperationException($"Cell phone number should be at least {MinLength} digits long");
            }

            var match = Regex.Match(
                cellPhoneNumber,
                CellPhoneNumberRegex,
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture
            );

            if (!match.Success)
            {
                throw new FormatException("Invalid cell phone number format");
            }

            return cellPhoneNumber;
        }
    }
}
