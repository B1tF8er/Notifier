﻿using Notifier.Contracts;
using System;

namespace Notifier.Configuration
{
    public class SqlConfiguration : ISqlConfiguration
    {
        public int Port => 440;

        public string Server => "localhost";

        public string User => "someone";

        public string Password => "5up3r53cur3";
    }
}
