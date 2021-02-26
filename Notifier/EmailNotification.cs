using System;

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

        public void Send(string message)
        {
            Console.WriteLine($"{message} via Email");
        }
    }
}
