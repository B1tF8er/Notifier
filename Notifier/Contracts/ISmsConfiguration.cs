using Notifier.Models;

namespace Notifier.Contracts
{
    public interface ISmsConfiguration
    {
        CellPhoneNumber Number { get; }
    }
}
