using static Notifier.Validators.SmptPortValidator;

namespace Notifier.Models
{
    public sealed class SmptPort
    {
        private readonly int value;

        private SmptPort(int smptPort) =>
            value = smptPort;

        public static SmptPort Create(int smptPort) =>
            new(smptPort.Validate());

        public static implicit operator int(SmptPort smptPort) =>
            smptPort.value;

        public static implicit operator SmptPort(int smptPort) =>
            Create(smptPort);

        public static bool operator ==(SmptPort lhs, SmptPort rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(SmptPort lhs, SmptPort rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            $"{value}";

        public override bool Equals(object obj) =>
            obj is SmptPort other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
