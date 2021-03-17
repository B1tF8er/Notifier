using System;

namespace Notifier.Models
{
    public sealed class User
    {
        private const int MinLength = 5;

        private readonly string value;

        private User(string user) => value = user;

        public static User Create(string user)
        {
            Guard(user);
            return new User(user);
        }

        public static void Guard(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null or empty");
            }

            if (user.Length < MinLength)
            {
                throw new InvalidOperationException($"User should be at least {MinLength} digits long");
            }
        }

        public static implicit operator string(User user) => user.value;

        public static implicit operator User(string user) => Create(user);

        public override string ToString() => value;
    }
}
