﻿using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;

namespace Notifier.Models
{
    public sealed class CellPhoneNumber
    {
        private const int CellPhoneNumberMinLenght = 10;

        private readonly string value;

        private CellPhoneNumber(string cellPhoneNumber) => value = cellPhoneNumber;

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

        public static implicit operator string(CellPhoneNumber cellPhoneNumber) =>
            cellPhoneNumber.value;

        public static implicit operator int(CellPhoneNumber cellPhoneNumber) =>
            Convert.ToInt32(cellPhoneNumber.value);

        public static implicit operator CellPhoneNumber(string cellPhoneNumber) =>
            Create(cellPhoneNumber);

        public static implicit operator CellPhoneNumber(int cellPhoneNumber) =>
            Create($"{cellPhoneNumber}");

        public static bool operator ==(CellPhoneNumber lhs, CellPhoneNumber rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(CellPhoneNumber lhs, CellPhoneNumber rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            value;

        public override bool Equals(object obj) =>
            obj is CellPhoneNumber other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
