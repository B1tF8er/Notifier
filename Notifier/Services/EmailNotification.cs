using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class EmailNotification : INotification
    {
        private readonly IEmailConfiguration emailConfiguration;

        public EmailNotification(IEmailConfiguration emailConfiguration) =>
            this.emailConfiguration = emailConfiguration;

        public async Task Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be empty.");
            }

            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via Email with: {emailConfiguration}");
        }
    }
}
