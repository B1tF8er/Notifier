using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SmsNotification : INotification
    {
        private readonly ISmsConfiguration smsConfiguration;

        public SmsNotification(ISmsConfiguration smsConfiguration) =>
            this.smsConfiguration = smsConfiguration;

        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via SMS with: {smsConfiguration}");
        }
    }
}
