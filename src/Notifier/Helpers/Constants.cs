namespace Notifier.Helpers
{
    internal static class Constants
    {
        internal static class Patterns
        {
            internal const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            internal const string CellPhoneNumberRegex = @"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$";
        }

        internal static class ErrorMessages
        {
            internal static class CellPhone
            {
                internal const string CannotBeNullOrEmpty = "Cell phone number cannot be null or empty";

                internal const string ShouldBeAtLeastNDigitsLong = "Cell phone number should be at least {0} digits long";

                internal const string InvalidFormat = "Invalid cell phone number format";
            }

            internal static class EmailAddress
            {
                internal const string CannotBeNullOrEmpty = "Email address cannot be null or empty";

                internal const string InvalidFormat = "Invalid email address format";
            }

            internal static class Password
            {
                internal const string CannotBeNullOrEmpty = "Password cannot be null or empty";

                internal const string ShouldBeAtLeastNDigitsLong = "Password should be at least {0} digits long";
            }

            internal static class Server
            {
                internal const string CannotBeNullOrEmpty = "Server cannot be null or empty";
            }

            internal static class SmtpPort
            {
                internal const string InvalidPort = "SMTP port is not valid";
            }

            internal static class SqlServerPort
            {
                internal const string InvalidPort = "SQL server port is not valid";
            }

            internal static class User
            {
                internal const string CannotBeNullOrEmpty = "User cannot be null or empty";

                internal const string ShouldBeAtLeastNDigitsLong = "User should be at least {0} digits long";
            }
        }
    }
}
