namespace Notifier.Contracts
{
    public interface IEmailConfiguration
    {
        int Port { get; }

        string FromAddress { get; }

        string ToAddress { get; }

        string User { get; }

        string Password { get; }
    }
}
