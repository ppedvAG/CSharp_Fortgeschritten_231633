using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Sonstiges;

internal class Program
{
	static void Main(string[] args)
	{
		List<Wagon> wagons = new List<Wagon>();
		for (int i = 0; i < 10; i++)
		{
			wagons.Add(new Wagon() { AnzSitze = 20, Farbe = "Rot" });
		}
		wagons.Add(new Wagon() { AnzSitze = 20, Farbe = "Blau" });
		Console.WriteLine(AlleObjekteGleich(wagons.ToArray()));

		Zug z = new();
		z += wagons[0];

		Console.WriteLine(z[0]);
		//z[0] = new Wagon();
		Console.WriteLine(z[10, "Rot"]);
    }

	static bool AlleObjekteGleich<T>(params T[] objekte)
	{
		//List<object?[]> values = new List<object?[]>();
		//foreach (T o in objekte)
		//{
		//	values.Add(o.GetType().GetProperties().Select(e => e.GetValue(o)).ToArray());
		//}

		//All: Schleife über die Liste und prüft die Bedingung
		//First: 1 == 1, 2 == 1, ...
		//Last: 1 == x, 2 == x, ..., x == x

		List<object?[]> values = objekte
			.Select(e => e!.GetType()
						   .GetProperties()
						   .Select(x => x.GetValue(e)).ToArray())
						   .ToList();
		return values.All(e => e.SequenceEqual(values.Last()));
	}
}

public class Zug
{
	public List<Wagon> Wagons = new();

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public Wagon this[int index] => Wagons[index];

	public Wagon this[int anzSitze, string farbe] => Wagons.First(e => e.AnzSitze == anzSitze && e.Farbe == farbe);
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon a, Wagon b)
	{
		//return a.GetType().GetProperties().Select(e => e.GetValue(e)).SequenceEqual(b.GetType().GetProperties().Select(e => e.GetValue(e)));
		return a.Farbe == b.Farbe && a.AnzSitze == b.AnzSitze;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}