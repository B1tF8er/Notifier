using Notifier.Contracts;
using System;
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
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be empty.");
            }

            await messageWriter
                .Write($"{message} via GUI")
                .ConfigureAwait(false);
        }
    }
}
