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
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via SQL with: {sqlConfiguration}");
        }
    }
}
