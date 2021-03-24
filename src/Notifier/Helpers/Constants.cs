namespace Notifier.Helpers
{
    internal static class Constants
    {
        internal static class Patterns
        {
            internal const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            internal const string CellPhoneNumberRegex = @"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$";
        }
    }
}
