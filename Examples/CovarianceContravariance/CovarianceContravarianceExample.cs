namespace DotNet10ExamplesStarter.Examples.CovarianceContravariance;

internal static class CovarianceContravarianceExample
{
    public static void Run()
    {
        IEnumerable<Car> cars = [new Audi()];
        IEnumerable<Vehicle> vehicles = cars; // kowariancja 

        IComparer<Vehicle> vehicleComparer =
            Comparer<Vehicle>.Create((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        IComparer<Car> carComparer = vehicleComparer; // kontrwariancja

        Console.WriteLine(vehicles.First().Name);
        Console.WriteLine(carComparer.Compare(new Car(), new Audi()));
    }
}

class Vehicle { public virtual string Name => "vehicle"; }
class Car : Vehicle { public override string Name => "car"; }
class Audi : Car { public override string Name => "audi"; }
