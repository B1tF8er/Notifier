using System;
using System.Collections.Generic;
using System.Linq;

namespace Notifier
{
    public static class Program
    {
        private static readonly IList<INotification> notificationServices = new List<INotification>
        {
            new EmailNotification(),
            new SmsNotification()
        };

        private static readonly IList<IGreeter> greeters = new List<IGreeter>
        {
            new SpanishGreeter(notificationServices),
            new EnglishGreeter(notificationServices)
        };

        private static readonly string separator = new string('+', 20);

        private static readonly Action<IGreeter> SayHello = (greeter) =>
        {
            Console.WriteLine(separator);
            Console.WriteLine($"-- {greeter.GetType()} --");
            Console.WriteLine(separator);

            greeter.SayHello();

            Console.WriteLine();
            Console.WriteLine();
        };

        public static void Main() => greeters.ToList().ForEach(SayHello);
    }
}
