namespace DotNet10ExamplesStarter.Examples.PartialClassesMethods;

sealed partial class Employee(string name)
{
    public string Name { get; private set; } = name;
    public string Description => $"Pracownik: {Name}";

    public void Rename(string value)
    {
        Name = value;
        OnNameChanged(name);
    }

    partial void OnNameChanged(string name);
}