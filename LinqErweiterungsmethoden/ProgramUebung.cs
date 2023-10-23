using System.Diagnostics;
using System.Text.Json;

internal class ProgramUebung
{
	static void Main(string[] args)
	{
		#region File lesen
		string readJson = File.ReadAllText(@"..\..\..\Personen.json");
		List<Person> personen = JsonSerializer.Deserialize<List<Person>>(readJson);
		#endregion

		//Hier eigenen Code schreiben

		var sorted = personen
			.GroupBy(e => e.Vorname)
			.Select(e => (e.Key, e.Count()))
			.OrderByDescending(e => e.Item2);
		sorted.TakeWhile(e => e.Item2 >= sorted.ElementAt(5).Item2);

		personen
			.GroupBy(e => e.Vorname)
			.ToDictionary(e => e.Key, e => e.Count())
			.OrderByDescending(e => e.Value)
			.Take(5);

		personen
			.Select(e => e.Job)
			.GroupBy(e => e.Titel)
			.Select(e => (e.Key, e.MaxBy(x => x.Gehalt)))
			.Order();
	}
}

///////////////////////////////////////////////////////////////////////////////

[DebuggerDisplay("Person - ID: {ID}, Vorname: {Vorname}, Nachname: {Nachname}, GebDat: {Geburtsdatum.ToString(\"yyyy.MM.dd\")}, Alter: {Alter}, " +
	"Jobtitel: {Job.Titel}, Gehalt: {Job.Gehalt}, Einstellungsdatum: {Job.Einstellungsdatum.ToString(\"yyyy.MM.dd\")}")]
public record Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies);

public record Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum);

///////////////////////////////////////////////////////////////////////////////