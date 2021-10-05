using static Notifier.Validators.SqlServerPortValidator;

namespace Notifier.Models
{
    public sealed class SqlServerPort
    {
        private readonly int _value;

        private SqlServerPort(int sqlServerPort) =>
            _value = sqlServerPort;

        public static SqlServerPort Create(int sqlServerPort) =>
            new(sqlServerPort.Validate());

        public static implicit operator int(SqlServerPort sqlServerPort) =>
            sqlServerPort._value;

        public static implicit operator SqlServerPort(int sqlServerPort) =>
            Create(sqlServerPort);

        public static bool operator ==(SqlServerPort lhs, SqlServerPort rhs) =>
            lhs?.Equals(rhs) ?? rhs is null;

        public static bool operator !=(SqlServerPort lhs, SqlServerPort rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            $"{_value}";

        public override bool Equals(object obj) =>
            obj is SqlServerPort other && _value == other._value;

        public override int GetHashCode() =>
            _value.GetHashCode();
    }
}
