using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class GuiNotification : INotification
    {
        private readonly IMessageWriter messageWriter;

        public GuiNotification(IMessageWriter messageWriter) =>
            this.messageWriter = messageWriter;

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await messageWriter
                .Write($"{message} via GUI")
                .ConfigureAwait(false);
        }
    }
}
