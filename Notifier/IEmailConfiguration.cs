namespace Notifier
{
    public interface IEmailConfiguration
    {
        int Port { get; }

        string FromAddress { get; }
    }
}
