using Notifier.Contracts;
using System;
using System.Threading.Tasks;

namespace Notifier.Services
{
    public class GuiNotification : INotification
    {
        public async Task Send(string message)
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine($"{message} via GUI");
        }
    }
}
