using System.Collections.Generic;

namespace Notifier
{
    public class SpanishGreeter : IGreeter
    {
        public IList<INotification> NotificationServices { get; }

        public string Greeting { get; }

        public SpanishGreeter(IList<INotification> notificationServices)
        {
            NotificationServices = notificationServices;
            Greeting = "Hola Mundo";
        }

        public void SayHello()
        {
            foreach (var notificationService in NotificationServices)
            {
                notificationService.Send(Greeting);
            }
        }
    }
}
