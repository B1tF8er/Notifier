using Notifier.Contracts;

namespace Notifier.Configuration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public int Port => 8000;

        public string FromAddress => "some@domain.com";

        public string ToAddress => "other@domain.com";

        public string User => "someone";

        public string Password => "5up3r53cur3";

        public override string ToString() =>
            $"Port: {Port} - From: {FromAddress} - To: {ToAddress} - Credentials: [{User}:{Password}]";
    }
}
