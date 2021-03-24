using System.Threading.Tasks;

namespace Notifier.Contracts
{
    public interface INotification
    {
        Task Send(string message);
    }
}
