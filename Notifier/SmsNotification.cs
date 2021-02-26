using System;

namespace Notifier
{
    public class SmsNotification : INotification, ISmsConfiguration
    {
        public int Number { get; }

        public SmsNotification()
        {
            Number = 1234568790;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{message} via SMS");
        }
    }
}
