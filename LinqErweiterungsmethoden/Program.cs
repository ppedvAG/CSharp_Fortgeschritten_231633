using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Listentheorie
		//IEnumerable: Bildet die Basis von allen Listentypen in C#
		//IEnumerable ist eine Anleitung zum Erstellen der fertigen Liste

		IEnumerable<int> range = Enumerable.Range(1, 1000); //Anleitung zum Erstellen der Range -> Expanding the Results View will enumerate the IEnumerable	
		//-> IEnumerable enthält keine Elemente
		//IEnumerable kann ausiteriert werden (mit ToList(), ToArray(), foreach) um die Elemente zu generieren
		foreach (int i in range) //Hier werden jetzt die Elemente bei jedem Schleifendurchlauf erzeugt
			Console.WriteLine(i); //Ablauf der Schleife: Gib mir das nächste Element, mache etwas mit dem Element -> Wiederholen bis keine neuen Elemente mehr kommen

		IEnumerable<int> bigRange = Enumerable.Range(1, 1_000_000_000); //-> Anleitung, Elemente werden nicht generiert (1ms)
		//bigRange.ToList(); //Hier werden jetzt die 1 Mrd. Elemente generiert und im RAM angelegt (3.6s)

		List<int> ints = Enumerable.Range(1, 100).ToList(); //Mit ToList() tatsächlich die Elemente erzeugen
		ints.Where(e => e % 2 == 0); //Anleitung, wie die fertige Liste erzeugt werden soll

		bigRange.Where(e => e % 2 == 0); //Benötigt auch nur 3ms

		//Enumerator
		//Komponente von IEnumerable, die dafür verantwortlich ist, das IEnumerable zu iterieren
		//3 Teile:
		//- Zeiger: Zeigt auf genau ein Element
		//- MoveNext(): Bewegt den Zeiger um ein Element nach rechts, und schreibt den Wert in Current hinein
		//- Reset(): Bewegt den Zeiger auf Position 0 zurück
		//GetEnumerator(): Gibt den unterliegenden Enumerator einer Liste zurück

		foreach (int i in ints) //Greift hier auf GetEnumerator() zu
		{
            Console.WriteLine(i);
        }

		//foreach per Hand/Zerlegt
		IEnumerator<int> enumerator = ints.GetEnumerator();
		while (enumerator.MoveNext())
			Console.WriteLine(enumerator.Current);
		#endregion

		#region Einfaches Linq
		ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Sum());

		ints.First(); //Gibt das erste Element zurück, Exception wenn kein Element gefunden wurde
		ints.FirstOrDefault(); //Gibt das erste Element zurück, default wenn kein Element gefunden wurde

		ints.Last(); //Gibt das letzte Element zurück, Exception wenn kein Element gefunden wurde
		ints.LastOrDefault(); //Gibt das letzte Element zurück, default wenn kein Element gefunden wurde

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Finde das erste Element, dass restlos durch 50 teilbar ist (-> Exception)
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //Finde das erste Element, dass restlos durch 50 teilbar ist (-> 0)
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objektliste
		//Predicate und Selector
		//Predicate: Func die einen bool zurück gibt, und generell weniger Elemente zurück gibt als in der Ursprungsliste vorhanden sind
		//Selektor: Func die ein T zurück gibt, wobei T der Typ des Felds im Selector ist. Der Selektor gibt immer gleich viele Elemente wie die Ursprungsliste hat zurück

		//Select
		//Ermöglicht die Transformation einer Liste in eine andere Form
		//2 Anwendungsfälle:

		//1. Fall
		//Extrahieren eines einzelnen Feldes (80% der Fälle)
		fahrzeuge.Select(e => e.Marke); //Nur die Marken als Liste

		//2. Transformieren der Liste
		fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren."); //String Liste

		//Alle Dateien in einem Verzeichnis haben ohne Endung und Pfad
		string[] paths = Directory.GetFiles(@"C:\Windows");
		List<string> fileNames = new();
		foreach (string path in paths)
			fileNames.Add(Path.GetFileNameWithoutExtension(path));

		//Linq-Repräsentation:
		List<string> namesLinq = Directory.GetFiles(@"C:\Windows").Select(Path.GetFileNameWithoutExtension).ToList();

		//Die Längen aller Textdateien (.txt) aus einem Ordner aufsummieren
		Directory
			.GetFiles(@"C:\Windows")
			.Where(e => Path.GetExtension(e) == ".txt")
			.Select(e => File.ReadAllLines(e).Length)
			.Sum();

		//Linq vereinfachen
		//Oftmals können Where und Select durch nachfolgende Linq Funktionen ausgetauscht werden
		Directory
			.GetFiles(@"C:\Windows")
			.Where(e => Path.GetExtension(e) == ".txt")
			.Sum(e => File.ReadAllLines(e).Length); //Select + Sum -> Sum

		fahrzeuge.Where(e => e.MaxV > 200).First();
		fahrzeuge.First(e => e.MaxV > 200); //Where + First -> First

		fahrzeuge.Select(e => e.MaxV).Average();
		fahrzeuge.Average(e => e.MaxV); //Select + Average -> Average

		//Aggregate
		//Wendet für jedes Element einer Liste eine Funktion. Das Ergebnis dieser Funktion wird in den Aggregator gespeichert

		//Sum mit Aggregate
		fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxV);

		//Liste printen
		Console.WriteLine(string.Join('\n', fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren.")));

		Console.WriteLine(fahrzeuge
			.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren.")
			.Aggregate(new StringBuilder(), (sb, str) => sb.AppendLine(str))
			.ToString());
		#endregion

		#region Erweiterungsmethoden
		9327421.Quersumme();
		int x = 237598329;
        Console.WriteLine(x.Quersumme());

		fahrzeuge.Shuffle();

        Console.WriteLine(fahrzeuge.AsString());
        Console.WriteLine(fahrzeuge.AsString(e => (e.Marke, e.MaxV, e.GetHashCode())));
		#endregion
    }
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

public enum FahrzeugMarke { Audi, BMW, VW }



//public class ReorderableEnumerable<T> : IEnumerable<T>
//{
//	public IEnumerable<T> values { get; set; }

//	private readonly List<Func<T, object>> ordererReminder = new();

//	public ReorderableEnumerable(IEnumerable<T> x) => values = x;

//	public IEnumerator<T> GetEnumerator() => values.GetEnumerator();

//	IEnumerator IEnumerable.GetEnumerator() => values.GetEnumerator();

//	public IEnumerable<T> OrderBy<TSelector>(Func<T, TSelector> selector)
//	{
//		ordererReminder.Add(selector);
//		IOrderedEnumerable<T> ordered = values.OrderBy(e => ordererReminder[0](e));
//		foreach (Func<T, TSelector> x in ordererReminder)
//		{
//			ordered = ordered.ThenBy(x);
//		}
//		return ordered.AsEnumerable();
//	}
//}