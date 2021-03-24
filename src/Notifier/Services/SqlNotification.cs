﻿using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SqlNotification : INotification
    {
        private readonly ISqlConfiguration sqlConfiguration;

        private readonly IMessageWriter messageWriter;

        public SqlNotification(ISqlConfiguration sqlConfiguration, IMessageWriter messageWriter) =>
            (this.sqlConfiguration, this.messageWriter) = (sqlConfiguration, messageWriter);

        public async Task Send(string message)
        {
            message.Guard(nameof(message));

            await messageWriter
                .Write($"{message} via SQL with: {sqlConfiguration}")
                .ConfigureAwait(false);
        }
    }
}