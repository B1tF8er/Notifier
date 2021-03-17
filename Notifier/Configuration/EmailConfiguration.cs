using Notifier.Contracts;
using Notifier.Models;

namespace Notifier.Configuration
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public SmptPort Port => SmptPort.Create(2525);

        public EmailAddress FromAddress => EmailAddress.Create("some@domain.com");

        public EmailAddress ToAddress => EmailAddress.Create("other@domain.com");

        public User User => User.Create("someone");

        public Password Password => Password.Create("5up3r53cur3");

        public override string ToString() =>
            $"Port: {Port} - From: {FromAddress} - To: {ToAddress} - Credentials: [{User}:{Password}]";
    }
}
