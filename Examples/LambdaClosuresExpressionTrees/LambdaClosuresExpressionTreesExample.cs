using System.Linq.Expressions;

namespace DotNet10ExamplesStarter.Examples.LambdaClosuresExpressionTrees;

internal static class LambdaClosuresExpressionTreesExample
{
    public static void Run()
    {
        var threshold = 100m;

        Func<Product, bool> compiled = p => p.Price >= threshold;
        Expression<Func<Product, bool>> tree = p => p.Price >= threshold;

        Console.WriteLine(compiled(new Product("Monitor", "black", 1200m)));
        Console.WriteLine($"Drzewo: {tree.Body.NodeType}, {tree.Body}");
    }
}

public sealed record Product(string Name, string Color, decimal Price);