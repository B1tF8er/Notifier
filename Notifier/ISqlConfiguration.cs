﻿namespace Notifier
{
    public interface ISqlConfiguration
    {
        int Port { get; }

        string Server { get; }

        string User { get; }

        string Password { get; }
    }
}
