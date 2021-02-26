using System;
using System.Threading.Tasks;

namespace Notifier
{
    public class EmailNotification : INotification, IEmailConfiguration
    {
        public int Port { get; }

        public string FromAddress { get; }

        public EmailNotification()
        {
            Port = 8000;
            FromAddress = "some@domain.com";
        }

        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via Email using port {Port} and from {FromAddress}");
        }
    }
}
