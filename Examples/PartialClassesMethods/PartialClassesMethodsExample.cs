namespace DotNet10ExamplesStarter.Examples.PartialClassesMethods;

internal static class PartialClassesMethodsExample
{
    public static void Run()
    {
        var employee = new Employee("Jan");
        employee.Rename("Jan Kowalski");
        Console.WriteLine(employee.Description);
    }
}