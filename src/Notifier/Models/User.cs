using static Notifier.Validators.UserValidator;

namespace Notifier.Models
{
    public sealed class User
    {
        private readonly string _value;

        private User(string user) =>
            _value = user;

        public static User Create(string user) =>
            new(user.Validate());

        public static implicit operator string(User user) =>
            user._value;

        public static implicit operator User(string user) =>
            Create(user);

        public static bool operator ==(User lhs, User rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(User lhs, User rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            _value;

        public override bool Equals(object obj) =>
            obj is User other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
