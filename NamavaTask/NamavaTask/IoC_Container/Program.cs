using IoC_Container.Interfaces;

class Program
{
    static void Main()
    {
        var container = new IocContainer();

        container.Register<ILogger, ConsoleLogger>(LifeTime.Singleton);
        container.Register<INotifier>(c => new EmailNotifier(c.Resolve<ILogger>()), LifeTime.Transient);

        var notifier = container.Resolve<INotifier>();
        notifier.Notify("Notify from our IoC");
    }
}
