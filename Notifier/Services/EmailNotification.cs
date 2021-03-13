using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class EmailNotification : INotification
    {
        private readonly IEmailConfiguration emailConfiguration;

        private readonly IMessageWriter messageWriter;

        public EmailNotification(IEmailConfiguration emailConfiguration, IMessageWriter messageWriter) =>
            (this.emailConfiguration, this.messageWriter) = (emailConfiguration, messageWriter);

        public async Task Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be empty.");
            }

            await messageWriter
                .Write($"{message} via Email with: {emailConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
