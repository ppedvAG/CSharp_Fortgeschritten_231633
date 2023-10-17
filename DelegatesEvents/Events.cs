namespace DelegatesEvents;

internal class Events
{
	/// <summary>
	/// Event: Statischer Punkt (nicht static), an den Methoden angehängt werden können (wie Delegate)
	/// Kann nicht instanziert werden
	/// 
	/// Zweigeteilte Entwicklung:
	/// 1. Entwicklerseite: Implementiert die Event-Variable und ruft das Event auf
	/// 2. Anwenderseite: Implementiert den Code des Events und hängt an das Event die Methode an
	/// Beispiel: Button -> Click
	/// </summary>
	event EventHandler TestEvent; //Entwicklerseite

	event EventHandler<TestEventArgs> DataEvent; //Eigene Datenstruktur die beim Event übergeben wird

	event EventHandler<int> IntEvent; //Parameter muss kein EventArgs sein

	static void Main(string[] args) => new Events().Test();

	public void Test()
	{
		TestEvent += Events_TestEvent; //Anwenderseite
		TestEvent(this, EventArgs.Empty); //Entwicklerseite

		DataEvent += Events_DataEvent;
		DataEvent(this, new TestEventArgs("Erfolg"));

		IntEvent += Events_IntEvent;
		IntEvent(this, 5);
	}

	private void Events_IntEvent(object sender, int e)
	{
		Console.WriteLine(e);
	}

	private void Events_DataEvent(object sender, TestEventArgs e)
	{
        Console.WriteLine(e.Status);
    }

	private void Events_TestEvent(object sender, EventArgs e) //Anwenderseite
	{
        Console.WriteLine("Das TestEvent wurde ausgeführt");
    }
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public TestEventArgs(string status)
	{
		Status = status;
	}
}