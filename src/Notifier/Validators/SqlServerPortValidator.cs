using System;
using System.Collections.Generic;
using System.Linq;
using static Notifier.Helpers.Constants.ErrorMessages.SqlServerPort;

namespace Notifier.Validators
{
    internal static class SqlServerPortValidator
    {
        private static readonly IEnumerable<int> ValidPorts = new List<int>
        {
            80,
            135,
            443,
            1433,
            1434,
            2382,
            2383,
            4022,
            7022
        };

        internal static int Validate(this int sqlServerPort)
        {
            var isValidPort = ValidPorts.Any(port => port == sqlServerPort);

            if (!isValidPort)
            {
                throw new ArgumentOutOfRangeException(nameof(sqlServerPort), InvalidPort);
            }

            return sqlServerPort;
        }
    }
}
