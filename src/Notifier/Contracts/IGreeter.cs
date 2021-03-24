using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifier.Contracts
{
    public interface IGreeter
    {
        IList<INotification> NotificationServices { get; }

        string Greeting { get; }

        Task SayHello();
    }
}
