using Notifier.Models;

namespace Notifier.Contracts
{
    public interface ISqlConfiguration
    {
        SqlServerPort Port { get; }

        Server Server { get; }

        User User { get; }

        Password Password { get; }
    }
}
