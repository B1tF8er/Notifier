using System.Threading.Tasks;

namespace Notifier
{
    public interface INotification
    {
        Task Send(string message);
    }
}
