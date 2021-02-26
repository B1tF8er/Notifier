using System.Collections.Generic;

namespace Notifier
{
    public class EnglishGreeter : IGreeter
    {
        public IList<INotification> NotificationServices { get; }

        public string Greeting { get; }

        public EnglishGreeter(IList<INotification> notificationServices)
        {
            NotificationServices = notificationServices;
            Greeting = "Hello World";
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
