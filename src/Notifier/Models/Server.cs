using static Notifier.Validators.ServerValidator;

namespace Notifier.Models
{
    public sealed class Server
    {
        private readonly string _value;

        private Server(string server) => _value = server;

        public static Server Create(string server) =>
            new(server.Validate());

        public static implicit operator string(Server server) =>
            server._value;

        public static implicit operator Server(string server) =>
            Create(server);

        public static bool operator ==(Server lhs, Server rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(Server lhs, Server rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            _value;

        public override bool Equals(object obj) =>
            obj is Server other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
