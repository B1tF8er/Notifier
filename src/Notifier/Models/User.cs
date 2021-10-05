using static Notifier.Validators.UserValidator;

namespace Notifier.Models
{
    public sealed class User
    {
        private readonly string value;

        private User(string user) =>
            value = user;

        public static User Create(string user) =>
            new(user.Validate());

        public static implicit operator string(User user) =>
            user.value;

        public static implicit operator User(string user) =>
            Create(user);

        public static bool operator ==(User lhs, User rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(User lhs, User rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            value;

        public override bool Equals(object obj) =>
            obj is User other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
