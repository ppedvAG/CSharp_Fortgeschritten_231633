using System.Reflection;

namespace Reflection;

internal class Program
{
	private int X;

	static void Main(string[] args)
	{
		//Type
		//Jedes Objekt hat einen Type -> Reflection ist auf jedem Objekt möglich
		//2 Möglichkeiten einen Typen zu erhalten
		Program p = new Program();

		Type gt = p.GetType(); //Der Type gt ist unabhängig vom Objekt
		Type to = typeof(Program);

		//Über ein Type Objekt können alle Möglichen Dinge über ein Objekt herausgefunden werden
		gt.GetProperties();
		gt.GetMethods();
        Console.WriteLine(gt.IsPublic);

		object program = Activator.CreateInstance(gt); //Ermöglicht das Erstellen von Objekten über Types (statt new)

		object p2 = Convert.ChangeType(program, typeof(Program)); //Casting ohne Cast

		/////////////////////////////////////////////////////////////

		//private Felder angreifen
		gt.GetField("X"); //null, weil private
		FieldInfo fi = gt.GetField("X", BindingFlags.NonPublic | BindingFlags.Instance);
		fi.SetValue(p2, 5); //SetValue, GetValue benötigen ein Objekt auf das diese Funktion angewandt werden soll
		fi.GetValue(p2);

		/////////////////////////////////////////////////////////////
		
		Assembly assembly = Assembly.GetExecutingAssembly(); //Alle Informationen über die derzeitige DLL/das Projekt

		Assembly a = Assembly.LoadFrom(@"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2023_10_16\DelegatesEvents\bin\Debug\net7.0\DelegatesEvents.dll"); //Externe DLL laden

		Type compType = a.GetType("DelegatesEvents.Component"); //Type aus der DLL holen

		object comp = Activator.CreateInstance(compType); //Objekt aus dem Typen erstellen

		compType.GetEvent("ProcessStarted").AddEventHandler(comp, () => Console.WriteLine("Prozess gestartet"));
		compType.GetEvent("ProcessEnded").AddEventHandler(comp, () => Console.WriteLine("Prozess beendet"));
		compType.GetEvent("Progress").AddEventHandler(comp, (int i) => Console.WriteLine($"Fortschritt: {i}"));

		compType.GetMethod("DoWork").Invoke(comp, null);
	}
}