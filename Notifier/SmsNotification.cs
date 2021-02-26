using System;
using System.Threading.Tasks;

namespace Notifier
{
    public class SmsNotification : INotification, ISmsConfiguration
    {
        public int Number { get; }

        public SmsNotification()
        {
            Number = 1234568790;
        }

        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via SMS using the cell phone number {Number}");
        }
    }
}
