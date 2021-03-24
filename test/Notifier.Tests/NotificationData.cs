using System.Collections.Generic;

namespace Notifier.Tests
{
    public static class NotificationData
    {
        private const string ExpectedErrorMessage = "Cannot be null or empty. (Parameter 'message')";

        public static IEnumerable<object[]> Messages()
        {
            yield return new object[] { default(string), ExpectedErrorMessage };
            yield return new object[] { "", ExpectedErrorMessage };
            yield return new object[] { "     ", ExpectedErrorMessage };
        }
    }
}
