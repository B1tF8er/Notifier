using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class EmailNotification : INotification, IEmailConfiguration
    {
        public int Port { get; }

        public string FromAddress { get; }

        public string ToAddress { get; }

        public string User { get; }

        public string Password { get; }

        public EmailNotification()
        {
            Port = 8000;
            FromAddress = "some@domain.com";
            ToAddress = "other@domain.com";
            User = "someone";
            Password = "5up3r53cur3";
        }

        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via Email using port {Port} and from {FromAddress} to {ToAddress} with credentials [{User}:{Password}]");
        }
    }
}
