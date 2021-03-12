using Notifier.Contracts;

namespace Notifier.Configuration
{
    public class SmsConfiguration : ISmsConfiguration
    {
        public int Number => 1234567890;

        public override string ToString() =>
            $"Number: {Number}";
    }
}
