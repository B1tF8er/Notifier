using System;

namespace Notifier.Helpers
{
    internal static class StringExtensions
    {
        internal static void Guard(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(parameterName, "Cannot be null or empty.");
            }
        }
    }
}
