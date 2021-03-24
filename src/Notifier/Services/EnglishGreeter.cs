using Notifier.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifier.Services
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

        public async Task SayHello()
        {
            foreach (var notificationService in NotificationServices)
            {
                await notificationService.Send(Greeting).ConfigureAwait(false);
            }
        }
    }
}
