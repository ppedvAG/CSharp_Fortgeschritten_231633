namespace Multithreading;

internal class _02_ThreadMitParameter
{
	static void Main(string[] args)
	{
		Thread t = new Thread(Run); //Delegate mit void und einem object Parameter
		t.Start((Max: 200, Inkrement: 2)); //Daten bei Start übergeben

		//t.Start(new ThreadData(new Person(), new Person(), ""));

		//Thread mit Callback (Rückgabewert)
		object ergebnis;
		Action<int> result = retValue => ergebnis = retValue;
		Thread retThread = new Thread(RunWithReturn);
		retThread.Start(result);

		retThread.Join(); //Auf Ergebnis warten

        for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");
	}

	static void Run(object o)
	{
		if (o is Tuple<int, int> x)
		{
			for (int i = 0; i < x.Item1; i+=x.Item2)
				Console.WriteLine($"Side Thread: {i}");
		}
	}

	static void RunWithReturn(object o)
	{
		if (o is Action<int> a)
		{
			Random r = new Random();
			int zahl = r.Next();
			int ergebnis = zahl % 12;
			a(ergebnis);
		}
	}
}

public record Person(int ID, string Name, int Alter);

public record ThreadData(Person Selbst, Person Vorgesetzter, string Arbeitsort);