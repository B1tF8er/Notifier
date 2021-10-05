using System;
using static Notifier.Helpers.Constants.ErrorMessages.Server;

namespace Notifier.Validators
{
    internal static class ServerValidator
    {
        internal static string Validate(this string server)
        {
            if (string.IsNullOrWhiteSpace(server))
            {
                throw new ArgumentNullException(nameof(server), CannotBeNullOrEmpty);
            }

            return server;
        }
    }
}
