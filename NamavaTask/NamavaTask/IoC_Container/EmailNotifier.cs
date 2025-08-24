using IoC_Container.Interfaces;

public class EmailNotifier : INotifier
{
    private readonly ILogger _logger;
    public EmailNotifier(ILogger logger)
    {
        _logger = logger;
    }

    public void Notify(string msg)
    {
        _logger.Log($"Sending email: {msg}");
    }
}