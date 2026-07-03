using DotNet10ExamplesStarter.Examples.ServiceLocator;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet10ExamplesStarter.Examples.DependencyInjection;

internal static class DependencyInjectionExample
{
    public static void Run()
    {
        ServiceProvider services = new ServiceCollection()
            .AddSingleton<IClock, SystemClock>()
            .AddTransient<ReportGenerator>()
            .BuildServiceProvider();

        ReportGenerator reportGenerator = services.GetRequiredService<ReportGenerator>();

        Console.WriteLine(reportGenerator.Create());
    }
}

public sealed class ReportGenerator(IClock clock, IServiceProvider sp)
{
    public string Create() => $"Raport: {clock.Now:yyyy-MM-dd}";
}
