using static Notifier.Validators.SqlServerPortValidator;

namespace Notifier.Models
{
    public sealed class SqlServerPort
    {
        private readonly int value;

        private SqlServerPort(int sqlServerPort) =>
            value = sqlServerPort;

        public static SqlServerPort Create(int sqlServerPort) =>
            new(sqlServerPort.Validate());

        public static implicit operator int(SqlServerPort sqlServerPort) =>
            sqlServerPort.value;

        public static implicit operator SqlServerPort(int sqlServerPort) =>
            Create(sqlServerPort);

        public static bool operator ==(SqlServerPort lhs, SqlServerPort rhs) =>
            lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(SqlServerPort lhs, SqlServerPort rhs) =>
            !(lhs == rhs);

        public override string ToString() =>
            $"{value}";

        public override bool Equals(object obj) =>
            obj is SqlServerPort other && value == other.value;

        public override int GetHashCode() =>
            value.GetHashCode();
    }
}
