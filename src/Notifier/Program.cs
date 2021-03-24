using Notifier.Configuration;
using Notifier.Contracts;
using Notifier.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifier
{
    public static class Program
    {
        private static readonly ConsoleMessageWriter consoleMessageWriter = new ConsoleMessageWriter();

        private static readonly IList<INotification> notificationServices = new List<INotification>
        {
            new GuiNotification(consoleMessageWriter),
            new EmailNotification(new EmailConfiguration(), consoleMessageWriter),
            new SmsNotification(new SmsConfiguration(), consoleMessageWriter),
            new SqlNotification(new SqlConfiguration(), consoleMessageWriter)
        };

        private static readonly IList<IGreeter> greeters = new List<IGreeter>
        {
            new SpanishGreeter(notificationServices),
            new EnglishGreeter(notificationServices)
        };

        private static readonly string separator = new string('+', 30);

        public static async Task Main()
        {
            foreach (var greeter in greeters)
            {
                Header(greeter);
                await greeter.SayHello().ConfigureAwait(false);
                Footer();
            }
        }

        private static void Header(IGreeter greeter)
        {
            Console.WriteLine(separator);
            Console.WriteLine($"-- {greeter.GetType()} --");
            Console.WriteLine(separator);
        }

        private static void Footer()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
