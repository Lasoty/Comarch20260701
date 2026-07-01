namespace DotNet10ExamplesStarter.Examples.PartialClassesMethods;

sealed partial class Employee
{
    partial void OnNameChanged(string newName)
    {
        Console.WriteLine($"Zmieniono nazwę na {newName}");
    }
}