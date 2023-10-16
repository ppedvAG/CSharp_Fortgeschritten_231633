namespace Sprachfeatures;

internal class Program
{
	int Test = 0;

	readonly int Test2 = 0;

    public Program()
    {
		Test2 = 1;
    }

    static void Main(string[] args)
	{
		int i = 1;
		if (i.GetType() == typeof(object)) //Prüft genau eine Übereinstimmung
		{
			//false
		}

		if (i is object) //Schaut auf Vererbungen
		{
			//true
		}

		//GetType() == typeof(...): Genauer Typvergleich
		//is: Bei Interfaces immer zu verwenden, generell bevorzugen

		if (i is object)
		{
			object o3 = (object) i; //Vereinfachen
		}

		if (i is object o2) { }

		int x = 3_2_8_9_5_7_2_3;
		double d = 329_587_235.23_895_737_593;

		//Unterschied zwischen class und struct

		//class
		//Referenztyp
		//Bei Zuweisungen wird das Objekt referenziert
		//Bei Vergleichen werden die Speicheradressen verglichen
		Program p1 = new Program();
		Program p2 = p1; //Referenz auf p1
		p2.Test = 10; //p1 und p2 sind Zeiger die auf das selbe Objekt im RAM-Speicher zeigen

        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode()); //Selbe Hash Codes da selbes Objekt

		//struct
		//Wertetyp
		//Bei Zuweisungen wird der Inhalt kopiert
		//Bei Vergleichen wird der Inhalt verglichen
		int original = 5;
		int neu = original;
		neu = 10;

		void Test() => Console.WriteLine("Test");

		//Konstruktor konfigurieren
		new Program(alter: 30, adresse: "Zuhause");
		new Program(vorname: "Max", adresse: "Ein Haus");
		//Statt 4, 20 Parameter

		string str = "Test";
        Console.WriteLine(str == "Test" ? "String ist Test" : "String ist nicht Test");

		//IDisposable: Resourcen freigeben, die außerhalb des Programms (DB, Webschnittstelle, File, ...) liegen
		//Ermöglicht using Block/using Statement
		using HttpClient client = new HttpClient();

		string fix = "DaS iST ein TesT";
		Console.WriteLine(char.ToUpper(fix[0]) + fix[1..]);

		//Null-Coalescing Operator: Nimm den Linken Wert wenn er nicht null ist, sonst den rechten Wert
		object o = null;
        Console.WriteLine(o != null ? o : "Platzhalter");
        Console.WriteLine(o ?? "Platzhalter"); //Selbiges wie darüber

		//Verbatim String (@-String): String, der Escape-Sequenzen ignoriert
		string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_08_22\M008";

		//Interpolated String ($-String): Code in einen String einbauen
		Console.WriteLine($"Der String (str) ist: {str}"); //Variable direkt einbinden
		Console.WriteLine($"Die Summe aus d und x ist: {d + x}"); //"Code" einbauen
        Console.WriteLine($"neu ist größer als 10: {(neu > 10 ? "Ja" : "Nein")}"); //Ternary-Operator einbauen
        Console.WriteLine($"Der string {str} ist: {str switch { "1" => "Eins", "2" => "Zwei", "3" => "Drei", _ => "Andere Zahl" }}");

		//Boolescher Switch
		switch (DateTime.Now.DayOfWeek)
		{
			case DayOfWeek.Monday:
			case DayOfWeek.Tuesday:
			case DayOfWeek.Wednesday:
			case DayOfWeek.Thursday:
			case DayOfWeek.Friday:
                Console.WriteLine("Wochentag");
				break;
			case DayOfWeek.Saturday:
			case DayOfWeek.Sunday:
                Console.WriteLine("Wochenende");
				break;
        }

		switch (DateTime.Now.DayOfWeek)
		{
			case >= DayOfWeek.Monday and <= DayOfWeek.Friday:
				Console.WriteLine("Wochentag");
				break;
			case DayOfWeek.Saturday or DayOfWeek.Sunday:
				Console.WriteLine("Wochenende");
				break;
		}

		if (o is not null) { }
		if (o != null) { }

		Person p = new(1, "Max");
        Console.WriteLine(p.ID);
        Console.WriteLine(p.Name);

		var (id, name) = p; //Deconstruct auch dabei

		Person p5 = new();

		Person2 pk = new(10);

		StringBuilder sb;
		Stopwatch sw;

		List<int> list = new();
		list.OrderBy(e => e);
		list.Order();

		string t = $"{{{str}}}";
    }

	//Konstruktor/Methoden konfigurierbar machen
    public Program(string vorname = "", string nachname = "", int alter = 0, string adresse = "")
    {
        
    }

    ~Program()
	{
		//Dieser Code wird ausgeführt, wenn der GC das Objekt einsammelt
        Console.WriteLine("GC");
    }
}

public record Person(int ID, string Name) //Record kann auch geöffnet werden
{
    public Person() : this(1, "Max")
    {
        
    }

    public void Test()
	{

	}
}

public class Person2
{
	public int id;

	public string name;

    public Person2()
    {
		Console.WriteLine("Standardkonstruktor");
    }

	public Person2(int id) : this() //this bei Konstruktoren: Konstruktoren verketten
	{
		this.id = id;
		Console.WriteLine($"ID: {id}");
	}

	public Person2(int id, string name) : this(id)
	{
		this.name = name; //Die Zeilen darunter werden vom verketteten Konstruktor übernommen
		//this.id = id;
		//Console.WriteLine($"ID: {id}");
	}
}