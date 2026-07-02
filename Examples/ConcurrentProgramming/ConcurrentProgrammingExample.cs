namespace DotNet10ExamplesStarter.Examples.ConcurrentProgramming;

internal static class ConcurrentProgrammingExample
{
    public static async void Run()
    {
        var sources = new[]
        {
            new DataSource("CRM", 800, false),
            new DataSource("ERP", 1400, false),
            new DataSource("Warehouse", 2600, false),
            new DataSource("Legacy", 1000, true),
            new DataSource("Analytics", 4200, false)
        };

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        var importer = new DataImporter();
        var report = await importer.ImportAsync(sources, cts.Token);

        Console.WriteLine("Import report:");
        Console.WriteLine($"Successfull sources: {report.Results.Count(x => x.Status == "Success")}");
        Console.WriteLine($"Failed sources:      {report.Results.Count(x => x.Status == "Failed")}");
        Console.WriteLine($"Cancelled sources:   {report.Results.Count(x => x.Status == "Cancelled")}");
        Console.WriteLine($"Total records:       {report.Results.Sum(x => x.RecordsImported)}");
    }
}

sealed class DataImporter
{
    public async Task<ImportReport> ImportAsync(IEnumerable<DataSource> sources, CancellationToken cancellationToken)
    {
        List<Task<SourceImportResult>> tasks = sources.Select(source => ImportSourceAsync(source, cancellationToken)).ToList();
        SourceImportResult[] results = await Task.WhenAll(tasks);
        return new ImportReport(results.ToList());
    }

    private async Task<SourceImportResult> ImportSourceAsync(DataSource source, CancellationToken cancellationToken)
    {
        try
        {
            var records = await source.LoadAsync(cancellationToken);
            Console.WriteLine($"{source.Name}: imported {records.Count} records");
            return new SourceImportResult(source.Name, "Success", records.Count, "OK");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"{source.Name} cancelled.");
            return new SourceImportResult(source.Name, "Cancelled", 0, "Timeout or cancellation");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{source.Name}: failed - {ex.Message}");
            return new SourceImportResult(source.Name, "Failed", 0, ex.Message);
        }
    }
}


internal class DataSource
{
    private readonly int _delayMs;
    private readonly bool _shouldFail;

    public DataSource(string name, int delayMs, bool shouldFail)
    {
        _delayMs = delayMs;
        _shouldFail = shouldFail;
        Name = name;
    }
    public string Name { get; }

    public async Task<List<ImportRecord>> LoadAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(_delayMs, cancellationToken);

        if (_shouldFail)
        {
            throw new InvalidOperationException($"Source {Name} failed");
        }

        return Enumerable.Range(1, 5)
            .Select(i => new ImportRecord($"{Name}-{i}", Random.Shared.Next(10, 100)))
            .ToList();
    }
}

internal record ImportRecord(string ExternalId, int Value);
internal record SourceImportResult(string SourceName, string Status, int RecordsImported, string Message);
internal record ImportReport(List<SourceImportResult> Results);
