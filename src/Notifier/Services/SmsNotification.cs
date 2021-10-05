using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SmsNotification : INotification
    {
        private readonly ISmsConfiguration _smsConfiguration;

        private readonly IMessageWriter _messageWriter;

        public SmsNotification(ISmsConfiguration smsConfiguration, IMessageWriter messageWriter) =>
            (this._smsConfiguration, this._messageWriter) = (smsConfiguration, messageWriter);

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await _messageWriter
                .Write($"{message} via SMS with: {_smsConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
