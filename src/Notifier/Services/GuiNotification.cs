using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class GuiNotification : INotification
    {
        private readonly IMessageWriter _messageWriter;

        public GuiNotification(IMessageWriter messageWriter) =>
            this._messageWriter = messageWriter;

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await _messageWriter
                .Write($"{message} via GUI")
                .ConfigureAwait(false);
        }
    }
}
