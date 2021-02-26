using System.Collections.Generic;

namespace Notifier
{
    public interface IGreeter
    {
        IList<INotification> NotificationServices { get; }

        string Greeting { get; }

        void SayHello();
    }
}
