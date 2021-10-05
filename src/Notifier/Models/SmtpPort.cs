using static Notifier.Validators.SmtpPortValidator;

namespace Notifier.Models
{
    public sealed class SmtpPort
    {
        private readonly int _value;

        private SmtpPort(int smtpPort) =>
            _value = smtpPort;

        public static SmtpPort Create(int smtpPort) =>
            new(smtpPort.Validate());

        public static implicit operator int(SmtpPort smtpPort) =>
            smtpPort._value;

        public static implicit operator SmtpPort(int smtpPort) =>
            Create(smtpPort);

        public static bool operator ==(SmtpPort lhs, SmtpPort rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(SmtpPort lhs, SmtpPort rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            $"{_value}";

        public override bool Equals(object obj) =>
            obj is SmtpPort other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
