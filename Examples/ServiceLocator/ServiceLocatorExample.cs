namespace DotNet10ExamplesStarter.Examples.ServiceLocator;

internal static class ServiceLocatorExample
{
    public static void Run()
    {
        var locator = new SimpleServiceLocator();
        locator.Register<IClock>(new SystemClock());

        Console.WriteLine(locator.Get<IClock>().Now);
    }
}

public sealed class SimpleServiceLocator
{
    private readonly Dictionary<Type, object> _services = [];

    public void Register<T>(T immplementation) where T : notnull
    {
        _services[typeof(T)] = immplementation;
    }

    public T Get<T>() where T : notnull => (T)_services[typeof(T)];
}

public interface IClock
{
    public DateTime Now { get; }
}

public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}