using System;
using static Notifier.Validators.CellphoneNumberValidator;

namespace Notifier.Models
{
    public sealed class CellPhoneNumber
    {
        private readonly string value;

        private CellPhoneNumber(string cellPhoneNumber) =>
            value = cellPhoneNumber;

        public static CellPhoneNumber Create(string cellPhoneNumber) =>
            new(cellPhoneNumber.Validate());

        public static CellPhoneNumber Create(int cellPhoneNumber) =>
            Create($"{cellPhoneNumber}");

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
