using System;
using System.Text.RegularExpressions;
using static Notifier.Helpers.Constants.Patterns;

namespace Notifier.Models
{
    public sealed class EmailAddress
    {
        private readonly string value;

        private EmailAddress(string emailAddress) => value = emailAddress;

        public static EmailAddress Create(string emailAddress)
        {
            Guard(emailAddress);
            return new EmailAddress(emailAddress);
        }

        private static void Guard(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress), "Email address cannot be null");
            }

            var match = Regex.Match(
                emailAddress,
                EmailRegex,
                RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            if (!match.Success)
            {
                throw new ArgumentException("Invalid email address format", nameof(emailAddress));
            }
        }

        public static implicit operator string(EmailAddress emailAddress) =>
            emailAddress.value;

        public static implicit operator EmailAddress(string emailAddress) =>
            Create(emailAddress);

        public static bool operator ==(EmailAddress lhs, EmailAddress rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(EmailAddress lhs, EmailAddress rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            value;

        public override bool Equals(object obj) =>
            obj is EmailAddress other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
