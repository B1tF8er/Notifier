using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SqlNotification : INotification
    {
        private readonly ISqlConfiguration _sqlConfiguration;

        private readonly IMessageWriter _messageWriter;

        public SqlNotification(ISqlConfiguration sqlConfiguration, IMessageWriter messageWriter) =>
            (this._sqlConfiguration, this._messageWriter) = (sqlConfiguration, messageWriter);

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await _messageWriter
                .Write($"{message} via SQL with: {_sqlConfiguration}")
                .ConfigureAwait(false);
        }
    }
}
