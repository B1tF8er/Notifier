using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;

namespace Notifier.Models
{
    public sealed class CellPhoneNumber
    {
        private const int CellPhoneNumberMinLenght = 10;

        private readonly string value;

        public CellPhoneNumber(string cellPhoneNumber) => value = cellPhoneNumber;

        public static CellPhoneNumber Create(string cellPhoneNumber)
        {
            Guard(cellPhoneNumber);
            return new CellPhoneNumber(cellPhoneNumber);
        }

        public static CellPhoneNumber Create(int cellPhoneNumber) => Create($"{cellPhoneNumber}");

        private static void Guard(string cellPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(cellPhoneNumber))
            {
                throw new ArgumentNullException(nameof(cellPhoneNumber), "Cell phone number cannot be null");
            }

            if (cellPhoneNumber.Length < CellPhoneNumberMinLenght)
            {
                throw new ArgumentException("Invalid cell phone number length", nameof(cellPhoneNumber));
            }

            var match = Regex.Match(
                cellPhoneNumber,
                CellPhoneNumberRegex,
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture
            );

            if (!match.Success)
            {
                throw new ArgumentException("Invalid cell phone number format", nameof(cellPhoneNumber));
            }
        }

        public static implicit operator string(CellPhoneNumber cellPhoneNumber) => cellPhoneNumber.value;

        public static implicit operator CellPhoneNumber(string cellPhoneNumber) => Create(cellPhoneNumber);

        public static implicit operator CellPhoneNumber(int cellPhoneNumber) => Create($"{cellPhoneNumber}");

        public override string ToString() => value;
    }
}
