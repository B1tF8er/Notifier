using System;
using static Notifier.Validators.CellPhoneNumberValidator;

namespace Notifier.Models
{
    public sealed class CellPhoneNumber
    {
        private readonly string _value;

        private CellPhoneNumber(string cellPhoneNumber) =>
            _value = cellPhoneNumber;

        public static CellPhoneNumber Create(string cellPhoneNumber) =>
            new(cellPhoneNumber.Validate());

        public static CellPhoneNumber Create(int cellPhoneNumber) =>
            Create($"{cellPhoneNumber}");

        public static implicit operator string(CellPhoneNumber cellPhoneNumber) =>
            cellPhoneNumber._value;

        public static implicit operator int(CellPhoneNumber cellPhoneNumber) =>
            Convert.ToInt32(cellPhoneNumber._value);

        public static implicit operator CellPhoneNumber(string cellPhoneNumber) =>
            Create(cellPhoneNumber);

        public static implicit operator CellPhoneNumber(int cellPhoneNumber) =>
            Create($"{cellPhoneNumber}");

        public static bool operator ==(CellPhoneNumber lhs, CellPhoneNumber rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(CellPhoneNumber lhs, CellPhoneNumber rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            _value;

        public override bool Equals(object obj) =>
            obj is CellPhoneNumber other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
