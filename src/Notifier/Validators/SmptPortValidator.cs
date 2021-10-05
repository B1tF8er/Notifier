using System;
using System.Collections.Generic;
using System.Linq;

namespace Notifier.Validators
{
    internal static class SmptPortValidator
    {
        private static readonly IEnumerable<int> validPorts = new List<int> { 25, 465, 587, 2525 };

        internal static int Validate(this int smptPort)
        {
            var isValidPort = validPorts.Any(port => port == smptPort);

            if (!isValidPort)
            {
                throw new ArgumentOutOfRangeException(nameof(smptPort), "SMPT port is not valid");
            }

            return smptPort;
        }
    }
}
