using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;
using static Notifier.Helpers.Constants.ErrorMessages.CellPhone;

namespace Notifier.Validators
{
    internal static class CellPhoneNumberValidator
    {
        private const int MinLength = 10;

        internal static string Validate(this string cellPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(cellPhoneNumber))
            {
                throw new ArgumentNullException(nameof(cellPhoneNumber), CannotBeNullOrEmpty);
            }

            if (cellPhoneNumber.Length < MinLength)
            {
                throw new InvalidOperationException(string.Format(ShouldBeAtLeastNDigitsLong, MinLength));
            }

            var match = Regex.Match(
                cellPhoneNumber,
                CellPhoneNumberRegex,
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture
            );

            if (!match.Success)
            {
                throw new FormatException(InvalidFormat);
            }

            return cellPhoneNumber;
        }
    }
}
