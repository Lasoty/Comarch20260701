namespace DotNet10ExamplesStarter.Examples.Iterators;

internal static class IteratorsExample
{
    public static void Run()
    {
        Console.WriteLine(string.Join(", ", Fibonacci(7)));
    }

    private static IEnumerable<long> Fibonacci(int count)
    {
        long a = 0;
        long b = 1;

        for (int i = 0; i < count; i++)
        {
            yield return a;
            checked //unchecked
            {
                (a, b) = (b, a + b);
            }
        }
    }
}
