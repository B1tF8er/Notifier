﻿using System;

namespace Notifier.Models
{
    public sealed class Server
    {
        private readonly string value;

        private Server(string server) => value = server;

        public static Server Create(string server)
        {
            Guard(server);
            return new Server(server);
        }

        private static void Guard(string server)
        {
            if (string.IsNullOrWhiteSpace(server))
            {
                throw new ArgumentNullException(nameof(server), "Server cannot be null or empty");
            }
        }

        public static implicit operator string(Server server) => server.value;

        public static implicit operator Server(string server) => Create(server);

        public override string ToString() => value;
    }
}
