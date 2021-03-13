using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SmsNotification : INotification
    {
        private readonly ISmsConfiguration smsConfiguration;

        private readonly IMessageWriter messageWriter;

        public SmsNotification(ISmsConfiguration smsConfiguration, IMessageWriter messageWriter) =>
            (this.smsConfiguration, this.messageWriter) = (smsConfiguration, messageWriter);

        public async Task Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be empty.");
            }

            await messageWriter
                .Write($"{message} via SMS with: {smsConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
