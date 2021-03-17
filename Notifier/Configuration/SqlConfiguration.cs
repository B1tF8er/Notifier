using Notifier.Contracts;
using Notifier.Models;

namespace Notifier.Configuration
{
    public class SqlConfiguration : ISqlConfiguration
    {
        public SqlServerPort Port { get; }

        public Server Server { get; }

        public User User { get; }

        public Password Password { get; }

        public SqlConfiguration()
        {
            Port = SqlServerPort.Create(443);
            Server = Server.Create("localhost");
            User = User.Create("someone");
            Password = Password.Create("5up3r53cur3");
        }

        public override string ToString() =>
            $"Port: {Port} - Server: {Server} - Credentials: [{User}:{Password}]";
    }
}
