using System.Data;

namespace DotNet10ExamplesStarter.Examples.AsyncAwait;

internal static class AsyncAwaitExample
{
    public static async void Run()
    {
        try
        {
            CancellationTokenSource src = new(TimeSpan.FromSeconds(2));
            var result = await CalculateAsync(2, 3, src.Token);
            Console.WriteLine($"2 + 3 = {result}");
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Operacja przerwana przez użytkownika");
        }
    }

    private static async Task<int> CalculateAsync(
        int first,
        int second,
        CancellationToken cancellationToken
    )
    {
        await Task.Delay(1000, cancellationToken); //3000 jeśli chcemy canceled exception.
        return first + second;
    }
}
