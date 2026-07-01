namespace DotNet10ExamplesStarter.Examples.DelegatesFuncAction;

internal static class DelegatesFuncActionExample
{
    public static void Run()
    {
        PriceRule rule = AddVat;
        rule += AddServiceFee;

        Func<int, int, int> add = static (a, b) => a + b;
        Action<string> log = Console.WriteLine;

        log($"Multicast zwraca wynik ostatniej metody: {rule(100):0.00}");
        log($"Func: 2+3 = {add(2, 3)}");

        CosTam(Console.WriteLine);
    }

    private static void CosTam(Action<string> logAction)
    {
        logAction("Udało się");
    }

    private static decimal AddVat(decimal net)
    {
        return net * 1.23m;
    }

    private static decimal AddServiceFee(decimal net)
    {
        return net + 10m;
    }


    private delegate decimal PriceRule(decimal net);
}
