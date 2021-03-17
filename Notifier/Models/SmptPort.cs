using System;
using System.Collections.Generic;
using System.Linq;

namespace Notifier.Models
{
    public sealed class SmptPort
    {
        private static readonly IEnumerable<int> validPorts = new List<int> { 25, 465, 587, 2525 };

        private readonly int value;

        private SmptPort(int smptPort) => value = smptPort;

        public static SmptPort Create(int smptPort)
        {
            Guard(smptPort);
            return new SmptPort(smptPort);
        }

        public static void Guard(int smptPort)
        {
            var isValidPort = validPorts.Any(port => port == smptPort);

            if (!isValidPort)
            {
                throw new ArgumentOutOfRangeException(nameof(smptPort), "SMPT Port is not valid");
            }
        }

        public static implicit operator int(SmptPort smptPort) => smptPort.value;

        public static implicit operator SmptPort(int smptPort) => Create(smptPort);

        public override string ToString() => $"{value}";
    }
}
