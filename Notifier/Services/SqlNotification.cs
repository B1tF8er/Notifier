using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SqlNotification : INotification, ISqlConfiguration
    {
        public int Port { get; }

        public string Server { get; }

        public string User { get; }

        public string Password { get; }

        public SqlNotification()
        {
            Port = 440;
            Server = "localhost";
            User = "someone";
            Password = "5up3r53cur3";
        }

        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via SQL using port {Port} and server {Server} with credentials [{User}:{Password}]");
        }
    }
}
