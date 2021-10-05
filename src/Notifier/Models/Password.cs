using static Notifier.Validators.PasswordValidator;

namespace Notifier.Models
{
    public sealed class Password
    {
        private readonly string value;

        private Password(string password) =>
            value = password;

        public static Password Create(string password) =>
            new(password.Validate());

        public static implicit operator string(Password password) =>
            password.value;

        public static implicit operator Password(string password) =>
            Create(password);

        public static bool operator ==(Password lhs, Password rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(Password lhs, Password rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            value;

        public override bool Equals(object obj) =>
            obj is Password other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
