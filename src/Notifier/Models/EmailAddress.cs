using static Notifier.Validators.EmailAddressValidator;

namespace Notifier.Models
{
    public sealed class EmailAddress
    {
        private readonly string _value;

        private EmailAddress(string emailAddress) =>
            _value = emailAddress;

        public static EmailAddress Create(string emailAddress) =>
            new(emailAddress.Validate());

        public static implicit operator string(EmailAddress emailAddress) =>
            emailAddress._value;

        public static implicit operator EmailAddress(string emailAddress) =>
            Create(emailAddress);

        public static bool operator ==(EmailAddress lhs, EmailAddress rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(EmailAddress lhs, EmailAddress rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            _value;

        public override bool Equals(object obj) =>
            obj is EmailAddress other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
