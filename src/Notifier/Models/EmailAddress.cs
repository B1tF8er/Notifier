using static Notifier.Validators.EmailAddressValidator;

namespace Notifier.Models
{
    public sealed class EmailAddress
    {
        private readonly string value;

        private EmailAddress(string emailAddress) =>
            value = emailAddress;

        public static EmailAddress Create(string emailAddress) =>
            new(emailAddress.Validate());

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
