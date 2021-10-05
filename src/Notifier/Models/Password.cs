using static Notifier.Validators.PasswordValidator;

namespace Notifier.Models
{
    public sealed class Password
    {
        private readonly string _value;

        private Password(string password) =>
            _value = password;

        public static Password Create(string password) =>
            new(password.Validate());

        public static implicit operator string(Password password) =>
            password._value;

        public static implicit operator Password(string password) =>
            Create(password);

        public static bool operator ==(Password lhs, Password rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(Password lhs, Password rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            _value;

        public override bool Equals(object obj) =>
            obj is Password other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
