namespace DotNet10ExamplesStarter.Examples.GenericTypes;

internal static class GenericTypesExample
{
    public static void Run()
    {
        var buffer = new MyGenericArray<string>(3);
        buffer.Add("C#");
        buffer.Add(".NET");
        buffer.Add("Leszek");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Generic collection item [{i+1}]: {buffer[i]}");
        }

        IRepository<Person> repo = new InMemoryRepository<Person>();
        repo.Add(new Person("Ala", 25, true));
    }
}

public sealed class MyGenericArray<T>(int capacity)
{
    private readonly T[] _items = new T[capacity];
    private int _count;

    public void Add(T item) => _items[_count++] = item;
    public T this[int index] => _items[index];
}

public interface IRepository<T> where T : class
{
    void Add(T item);
    IReadOnlyCollection<T> GetAll();
}

public sealed class InMemoryRepository<T> : IRepository<T> where T: class
{
    private readonly List<T> _items = [];

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items;
    }
}

public sealed record Person(string Name, int Age, bool CanCode);