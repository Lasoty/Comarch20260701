namespace DotNet10ExamplesStarter.Examples.LinqRelationalXml;

internal static class LinqRelationalXmlExample
{
    public static void Run()
    {
        string[] words = ["jeden", "dwa", "trzy", "cztery", "piec"];

        var methodSyntax = words
            .Where(x => x.Length == 5)
            .OrderBy(x => x)
            .Select(x => new { Lower = x.ToLowerInvariant(), Upper = x.ToUpperInvariant() });

        var querySyntax = from w in words
            where w.Length == 5
            orderby w
            select w.ToLower();

    }
}
