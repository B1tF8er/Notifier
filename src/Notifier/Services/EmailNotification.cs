using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class EmailNotification : INotification
    {
        private readonly IEmailConfiguration _emailConfiguration;

        private readonly IMessageWriter _messageWriter;

        public EmailNotification(IEmailConfiguration emailConfiguration, IMessageWriter messageWriter) =>
            (this._emailConfiguration, this._messageWriter) = (emailConfiguration, messageWriter);

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await _messageWriter
                .Write($"{message} via Email with: {_emailConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
