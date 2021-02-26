using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task SayHello()
        {
            foreach (var notificationService in NotificationServices)
            {
                await notificationService.Send(Greeting).ConfigureAwait(false);
            }
        }
    }
}
