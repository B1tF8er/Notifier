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
        private static readonly ConsoleMessageWriter _consoleMessageWriter = new();

        private static readonly IList<INotification> NotificationServices = new List<INotification>
        {
            new GuiNotification(_consoleMessageWriter),
            new EmailNotification(new EmailConfiguration(), _consoleMessageWriter),
            new SmsNotification(new SmsConfiguration(), _consoleMessageWriter),
            new SqlNotification(new SqlConfiguration(), _consoleMessageWriter)
        };

        private static readonly IList<IGreeter> Greeters = new List<IGreeter>
        {
            new SpanishGreeter(NotificationServices),
            new EnglishGreeter(NotificationServices)
        };

        private static readonly string _separator = new('+', 30);

        public static async Task Main()
        {
            foreach (var greeter in Greeters)
            {
                Header(greeter);
                await greeter.SayHello().ConfigureAwait(false);
                Footer();
            }
        }

        private static void Header(IGreeter greeter)
        {
            Console.WriteLine(_separator);
            Console.WriteLine($"-- {greeter.GetType()} --");
            Console.WriteLine(_separator);
        }

        private static void Footer()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
