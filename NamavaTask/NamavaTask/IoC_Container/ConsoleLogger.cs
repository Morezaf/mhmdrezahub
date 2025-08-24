using IoC_Container.Interfaces;

public class ConsoleLogger : ILogger
{
    public void Log(string msg)
    {
        Console.WriteLine($"[LOG] {msg}");
    }
}
