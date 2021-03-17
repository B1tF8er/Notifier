using System;
using System.Text.RegularExpressions;

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
            if (emailAddress is null)
            {
                throw new ArgumentNullException(nameof(emailAddress), "Email address cannot be null");
            }

            var match = Regex.Match(
                emailAddress,
                @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            if (!match.Success)
                throw new ArgumentException("Invalid Email address format", nameof(emailAddress));
        }

        public static implicit operator string(EmailAddress emailAddress) => emailAddress.value;

        public static implicit operator EmailAddress(string emailAddress) => Create(emailAddress);

        public override string ToString() => value;
    }
}
