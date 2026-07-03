namespace DotNet10ExamplesStarter.Examples.UnitTestsAaa;

internal static class UnitTestsAaaExample
{
    public static void Run()
    {
    }
}

public class InvoiceService(IDiscountProvider discountProvider)
{

    public Invoice CreateInvoice(IEnumerable<Item> lines, string receiver)
    {
        if (lines is null || !lines.Any())
            throw new ArgumentException($"Parameter {nameof(lines)} should have more than 0 lines.");

        Invoice invoice = new()
        {
            Lines = lines,
            Sender = "NADALA Software",
            Receiver = receiver,
            TotalAmount = CalculateTotal(lines, receiver)
        };

        return invoice;
    }

    private decimal CalculateTotal(IEnumerable<Item> lines, string receiver)
    {
        decimal total = lines.Sum(line => line.price * line.count);

        total -= total * discountProvider.GetDiscount(receiver);
        return total;
    }
}

public interface IDiscountProvider
{
    decimal GetDiscount(string receiver);
}

public record Invoice
{
    public string Sender { get; set; }

    public string Receiver { get; set; }

    public IEnumerable<Item> Lines { get; set; }

    public decimal TotalAmount { get; set; }
}

public record Item(string Name, int count, decimal price);