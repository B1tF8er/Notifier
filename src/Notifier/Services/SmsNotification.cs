using Notifier.Contracts;
using Notifier.Helpers;
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
            message.Guard(nameof(message));

            await messageWriter
                .Write($"{message} via SMS with: {smsConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
