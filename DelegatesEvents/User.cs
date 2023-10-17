namespace DelegatesEvents;

/// <summary>
/// Anwenderseite, hier wird die Komponente erstellt und die Events angehängt
/// </summary>
internal class User
{
	static void Main(string[] args)
	{
		Component comp = new();
		comp.ProcessStarted += Comp_ProcessStarted;
		comp.ProcessEnded += Comp_ProcessEnded;
		comp.Progress += Comp_Progress;
		comp.DoWork();
	}

	private static void Comp_Progress(int i)
	{
        Console.WriteLine($"Fortschritt: {i}");
		//TB.Text = ... -> WPF
		//HTML generieren in ASP
		//Fortschritt in eine Datenbank schreiben
    }

	private static void Comp_ProcessStarted()
	{
        Console.WriteLine("Prozess gestartet");
	}

	private static void Comp_ProcessEnded()
	{
		//Sende dem Benutzer eine Benachrichtigung auf sein Mobiltelefon
		Console.WriteLine("Prozess beendet");
	}
}
