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

        public static void Guard(string password)
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

        public static implicit operator string(Password password) => password.value;

        public static implicit operator Password(string password) => Create(password);

        public override string ToString() => value;
    }
}
