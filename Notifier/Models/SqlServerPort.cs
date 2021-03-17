using System;
using System.Collections.Generic;
using System.Linq;

namespace Notifier.Models
{
    public sealed class SqlServerPort
    {
        private static readonly IEnumerable<int> validPorts = new List<int> { 80, 135, 443, 1433, 1434, 2382, 2383, 4022, 7022 };

        private readonly int value;

        private SqlServerPort(int sqlServerPort) => value = sqlServerPort;

        public static SqlServerPort Create(int sqlServerPort)
        {
            Guard(sqlServerPort);
            return new SqlServerPort(sqlServerPort);
        }

        public static void Guard(int sqlServerPort)
        {
            var isValidPort = validPorts.Any(port => port == sqlServerPort);

            if (!isValidPort)
            {
                throw new ArgumentOutOfRangeException(nameof(sqlServerPort), "SQL server port is not valid");
            }
        }

        public static implicit operator int(SqlServerPort sqlServerPort) => sqlServerPort.value;

        public static implicit operator SqlServerPort(int sqlServerPort) => Create(sqlServerPort);

        public override string ToString() => $"{value}";
    }
}
