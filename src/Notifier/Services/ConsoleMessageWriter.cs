﻿using Notifier.Contracts;
using Notifier.Helpers;
using System.Threading.Tasks;
using static System.Console;

namespace Notifier.Services
{
    public class ConsoleMessageWriter : IMessageWriter
    {
        public async Task Write(string message) =>
            await Task
                .Run(() => {
                    message.Guard(nameof(message));

                    WriteLine(message);
                })
                .ConfigureAwait(false);
    }
}
