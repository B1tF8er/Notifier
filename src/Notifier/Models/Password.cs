using System;

namespace Notifier.Models
{
    public sealed class Password
    {
        private const int MinLength = 10;

        private readonly string value;

        private Password(string password) => value = password;

        public static Password Create(string password)
        {
            Guard(password);
            return new Password(password);
        }

        private static void Guard(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null or empty");
            }

            if (password.Length < MinLength)
            {
                throw new InvalidOperationException($"Password should be at least {MinLength} digits long");
            }
        }

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
