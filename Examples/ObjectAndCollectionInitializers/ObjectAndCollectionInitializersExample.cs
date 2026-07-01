namespace DotNet10ExamplesStarter.Examples.ObjectAndCollectionInitializers;

internal static class ObjectAndCollectionInitializersExample
{
    public static void Run()
    {
        Cat cat = new Cat() { Age = 10, Name = "Fluffy" };
        Cat cat2 = new() { Age = 10, Name = "Fluffy" };

        List<Cat> cats = new List<Cat>() { cat, cat2, new() { Age = 14, Name = "Sasha" } };
        List<Cat> cats2 = [cat, cat2, new() { Age = 14, Name = "Sasha" }];

        Dictionary<int, string> names = new() { [7] = "seven", [9] = "nine" };
    }
}


public sealed record Cat
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}