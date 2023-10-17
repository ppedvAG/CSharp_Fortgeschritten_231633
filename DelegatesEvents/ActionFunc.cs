namespace DelegatesEvents;

internal class ActionFunc
{
	public static List<int> ints = new List<int>();

	static void Main(string[] args)
	{
		//Action, Predicate, Func: Vorgegebene Delegates, die an verschiedenen Stellen in der Sprache vorkommen
		//z.B.: Linq, Multitasking, Reflection, ...
		//Essentiell für die Fortgeschrittene Programmierung
		//Können alles was in dem vorherigen Teil besprochen wurde

		//Action: Delegate mit void und bis zu 16 Parametern
		//-> Generischer Container, der beliebig viele void Methoden halten kann
		Action<int, int> action = Addiere;
		action(4, 5);
		action?.Invoke(7, 9); //Delegate ausführen

		//Methode konfigurieren über Action Parameter
		DoAction(4, 7, Addiere);
		DoAction(9, 5, Subtrahiere);
		DoAction(9, 5, action);

		//Praktisches Beispiel
		ints.AddRange(Enumerable.Range(1, 100));

		ints.ForEach(Quadriere); //Struktur: void(int)
		void Quadriere(int n) => Console.WriteLine(Math.Pow(n, 2));

		//ForEach im Detail
		foreach (int i in ints)
			Quadriere(i);


		//Func: Methode mit Rückgabewert (statt void) und bis zu 16 Parametern
		//Letztes generisches Typargument ist der Rückgabetyp
		Func<int, int, double> func = Multipliziere;
		double d = func(5, 9); //Ergebnis aus Func heraus holen
		//double d2 = func?.Invoke(4, 8); //Könnte null sein durch ?.Invoke(...)
		double? d2 = func?.Invoke(4, 8); //Nullable Double, durch ? am Ende eines Typens, kann dieser Typ mit null befüllt werden
		//double d3 = d2 != null ? d2.Value : double.NaN;
		//double d3 = d2 ?? double.NaN;
		double d3 = func?.Invoke(4, 8) ?? double.NaN; //Wenn das Ergebnis von func?.Invoke nicht null ist, nimm das Ergebnis, sonst NaN

		//Methode konfigurieren über Func Parameter
		DoFunc(4, 9, Multipliziere);
		DoFunc(4, 9, Dividiere);
		DoFunc(4, 9, func);

		//Praktische Beispiele
		ints.Where(CheckDiv2);
		//Funktion, die einen Parameter nimmt und prüft ob dieser durch 2 teilbar ist
		//Diese Funktion soll bei Where übergeben werden#
		bool CheckDiv2(int x) => x % 2 == 0;

		//Anonyme Methoden
		//Methoden ohne direkte Initialisierung, die nur einmal als Methodenzeiger bei Delegates verwendet werden
		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		//Anwenden von anonymen Funktionen
		DoAction(4, 9, (x, y) => Console.WriteLine($"{x} + {y} = {x + y}"));
		DoFunc(39, 6, (x, y) => (double) x % y);

		ints.ForEach(n => Console.WriteLine($"{n}^2={Math.Pow(n, 2)}")); //Action mit einem Parameter
		ints.Where(e => e % 2 == 0); //Func mit int als Parameter und double als Rückgabewert
	}

	#region Action
	public static void Addiere(int x, int y) => Console.WriteLine(x + y);

	public static void Subtrahiere(int x, int y) => Console.WriteLine(x - y);

	public static void DoAction(int x, int y, Action<int, int> action) => action(x, y);
	#endregion

	#region Func
	public static double Multipliziere(int x, int y)
	{
		return x * y;
	}

	public static double Dividiere(int x, int y)
	{
		return x / y;
	}

	public static double DoFunc(int x, int y, Func<int, int, double> func)
	{
		double? d = func?.Invoke(x, y);
		if (d != null)
			return d.Value;
		return double.NaN;
		//return func?.Invoke(x, y) ?? double.NaN;
	}
	#endregion
}
