namespace DotNet10ExamplesStarter.Examples.NamedOptionalArguments;

internal static class NamedOptionalArgumentsExample
{
    public static void Run()
    {
        PrintOrderDetails(orderNumber: 31, productName: "Red mug", sellerName: "Gift shop", address: "Bydgoszcz");
        PrintOrderDetails(productName: "Blue mug", orderNumber: 32);
        PrintOrderDetails(productName: "Blue mug", orderNumber: 32, address: "Gdańsk");
    }

    private static void PrintOrderDetails(
        int orderNumber,
        string productName,
        string sellerName = "Internet Shop",
        string address = "N/A"
    )
    {
        Console.WriteLine($"#{orderNumber}: {productName}, sprzedawca={sellerName}, address=[{address}]");
    }
}
