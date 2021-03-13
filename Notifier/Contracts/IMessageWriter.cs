using System.Threading.Tasks;

namespace Notifier.Contracts
{
    public interface IMessageWriter
    {
        Task Write(string message);
    }
}
