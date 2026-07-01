namespace DotNet10ExamplesStarter.Examples.AnonymousMethodsAndLambdas;

internal static class AnonymousMethodsAndLambdasExample
{
    public static void Run()
    {
        Func<int, int> oldStyle = delegate (int x) { return x * x; };
        Func<int, int> lambdaBlock = x => { return x * x; };
        Func<int, int> lambdaExpression = x => x * x;

        Console.WriteLine($"{oldStyle(5)}, {lambdaBlock(6)}, {lambdaExpression(7)}");
    }
}
