﻿using Notifier.Contracts;
using Notifier.Models;

namespace Notifier.Configuration
{
    public class SmsConfiguration : ISmsConfiguration
    {
        public CellPhoneNumber Number { get; }

        public SmsConfiguration() =>
            Number = CellPhoneNumber.Create(1234567890);

        public override string ToString() =>
            $"Number: {Number}";
    }
}
