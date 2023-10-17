namespace DelegatesEvents;

internal class Delegates
{
	/// <summary>
	/// Delegate: Eigener Typ (wie Enum) der Methodenzeiger halten kann
	/// Das Delegate hat einen Aufbau wie eine Methode (Rückgabetyp, Name, Parameter), dieser Aufbau bestimmt die Funktionen die später angehängt werden können
	/// Zur Laufzeit können Methoden angehängt/abgehängt werden
	/// Das Delegate kann ausgeführt werden wie eine Methode
	/// </summary>
	public delegate void Vorstellungen(string name);

	static void Main(string[] args)
	{
		Vorstellungen v = new Vorstellungen(VorstellungDE); //Erstellung des Delegates mit einer Initialmethode (ohne Klammern)
		v("Max"); //Ausführung des Delegates wie eine Methode

		v += VorstellungEN; //Weitere Methode anhängen mit +=
		v("Tim"); //Es können auch mehrere Methoden an einem Delegate angehängt werden

		v += VorstellungEN;
		v += VorstellungEN;
		v += VorstellungEN; //Die selbe Methode kann mehrmals angehängt werden
		v("Leo");

		v -= VorstellungEN; //Mit -= können Methoden abgenommen werden
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN;
		v("Tom");

		v -= VorstellungDE; //Wenn der letzte Methodenzeiger abgenommen wird, ist das Delegate null
		//v("Lea");

		if (v is not null)
			v("Lea");

		v?.Invoke("Lea"); //Null Propagation: Führe den Code nach dem Fragezeichen aus, wenn die Variable nicht null ist

		foreach (Delegate dg in v?.GetInvocationList()) //Delegate auflisten
		{
            Console.WriteLine(dg.Method.Name);
        }
	}

	static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}