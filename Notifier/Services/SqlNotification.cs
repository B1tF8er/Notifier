using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class SqlNotification : INotification
    {
        private readonly ISqlConfiguration sqlConfiguration;

        public SqlNotification(ISqlConfiguration sqlConfiguration) =>
            this.sqlConfiguration = sqlConfiguration;

        public async Task Send(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be empty.");
            }

            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via SQL with: {sqlConfiguration}");
        }
    }
}
