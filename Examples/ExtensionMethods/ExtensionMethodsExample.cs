namespace DotNet10ExamplesStarter.Examples.ExtensionMethods;

internal static class ExtensionMethodsExample
{
    public static void Run()
    {
        Console.WriteLine("Ala ma kota. Kot ma Alę?".WordCount());
    }
}

public static class StringExtensions
{
    extension(string text)
    {
        public int WordCount()
        {
            return text.Split([' ', '.', '?', '!'], StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public string FirstLetterUpper()
        {
            return text.Insert(0, text[0].ToString().ToUpper()).Remove(1);
        }
    }

    //public static string FirstLetterUpper(this string text)
    //{
    //    return text.Insert(0, text[0].ToString().ToUpper()).Remove(1);
    //}
}