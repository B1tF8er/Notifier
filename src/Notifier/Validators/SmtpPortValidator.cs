using System;
using System.Collections.Generic;
using System.Linq;
using static Notifier.Helpers.Constants.ErrorMessages.SmtpPort;

namespace Notifier.Validators
{
    internal static class SmtpPortValidator
    {
        private static readonly IEnumerable<int> ValidPorts = new List<int> { 25, 465, 587, 2525 };

        internal static int Validate(this int smtpPort)
        {
            var isValidPort = ValidPorts.Any(port => port == smtpPort);

            if (!isValidPort)
            {
                throw new ArgumentOutOfRangeException(nameof(smtpPort), InvalidPort);
            }

            return smtpPort;
        }
    }
}
