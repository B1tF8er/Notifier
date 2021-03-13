using Notifier.Contracts;
using System.Threading.Tasks;
using static System.Console;

namespace Notifier.Services
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public async Task Write(string message) =>
            await Task
                .Run(() => WriteLine(message))
                .ConfigureAwait(false);
    }
}
