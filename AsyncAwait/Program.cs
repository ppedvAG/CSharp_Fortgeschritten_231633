using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		//MeasureTime(() =>
		//{
		//	Toast();
		//	Tasse();
		//	Kaffee();
		//}); //Synchron, 7s

		//Task.Run(() => MeasureTime(() =>
		//{
		//	Toast();
		//	Tasse();
		//	Kaffee();
		//})); //ThreadPool, daher abgebrochen

		//Task.Run(() => MeasureTime(() =>
		//{
		//	Toast();
		//	Tasse();
		//	Kaffee();
		//})).Wait(); //Wait sollte vermieden werden

		//Stopwatch stopwatch = Stopwatch.StartNew();
		//Task t1 = Task.Run(Toast);
		//Task t2 = Task.Run(Tasse);
		//t2.Wait();
		//Task t3 = Task.Run(Kaffee);
		//Task.WaitAll(t1, t3); //WaitAll sollte vermieden werden
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		//async und await
		//Wenn eine async Methode aufgerufen wird, wird diese als Task gestartet

		//Eine async Methode kann drei verschiedene Aufbauten haben
		//async void: Kann selber await verwenden, kann nicht awaited werden
		//async Task: Kann selber await verwenden, kann awaited werden
		//async Task<T>: Kann selber await verwenden, kann awaited werden und gibt ein Ergebnis zurück (T)

		////////////////////////////////////////////////////////////////////////////

		//Async ohne Objekte (async Task)

		//Stopwatch stopwatch = Stopwatch.StartNew();
		//ToastAsync();
		//TasseAsync();
		//KaffeeAsync();
		//Console.WriteLine(stopwatch.ElapsedMilliseconds); //14ms, async Methoden werden als Tasks gestartet -> laufen am ThreadPool

		//Stopwatch stopwatch = Stopwatch.StartNew();
		//await ToastAsync();
		//await TasseAsync();
		//await KaffeeAsync();
		//Console.WriteLine(stopwatch.ElapsedMilliseconds); //7s

		//Stopwatch stopwatch = Stopwatch.StartNew();
		//Task t1 = ToastAsync(); //Starte den Toast asynchron
		//Task t2 = TasseAsync(); //Starte den Tasse asynchron
		//await t2; //Warte hier auf die Tasse (für den Kaffee)
		//Task t3 = KaffeeAsync(); //Starte den Kaffee asynchron nachdem die Tasse fertig ist
		//await t3;
		//await t1; //Generell sollte await bei mehreren Tasks sortiert sein nach Dauer (ist nicht immer möglich)
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		////////////////////////////////////////////////////////////////////////////

		//Async mit Objekten (async Task<T>)

		//Stopwatch stopwatch = Stopwatch.StartNew();
		//Task<Toast> t1 = ToastObjectAsync(); //Starte den Toast asynchron
		//Task<Tasse> t2 = TasseObjectAsync(); //Starte den Tasse asynchron
		//Tasse tasse = await t2; //Hier kommt ein Objekt bei await heraus (ersetzt t2.Result)
		//Task<Kaffee> t3 = KaffeeObjectAsync(tasse); //Starte den Kaffee asynchron nachdem die Tasse fertig ist
		//Kaffee kaffee = await t3; //Hier kommt ein Objekt bei await heraus (ersetzt t3.Result)
		//Toast toast = await t1; //Hier kommt ein Objekt bei await heraus (ersetzt t1.Result)
		//Fruehstueck f = new Fruehstueck(toast, kaffee); //Hier unten fertige Objekte einsetzen
		//Console.WriteLine(stopwatch.ElapsedMilliseconds);

		Task<Toast> t1 = ToastObjectAsync();
		Task<Tasse> t2 = TasseObjectAsync();
		Task<Kaffee> t3 = KaffeeObjectAsync(await t2);
		Fruehstueck f = new Fruehstueck(await t1, await t3);
		//Fruehstueck f = new Fruehstueck(await t1, await KaffeeObjectAsync(await t2));

		//Task.Run: Ermöglicht, allen Code asynchron zu machen
		await Task.Run(Toast); //Synchrone Methode asynchron machen

		//Task.WhenAll, Task.WhenAny
		await Task.WhenAll(t1, t2, t3); //-> WaitAll mit await
		await Task.WhenAny(t1, t2, t3); //-> WaitAny mit await

		//Async Methode starten, verschiedene Dinge bevor der Task fertig ist machen, auf die Async warten mit await
	}

	static void MeasureTime(Action a)
	{
		Stopwatch sw = Stopwatch.StartNew();
		a();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }

	#region Synchron
	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Tasse()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Tasse fertig");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee fertig");
	}
	#endregion

	#region Async ohne Objekte
	static async Task ToastAsync()
	{
		await Task.Delay(4000); //await: Warte hier, bis der gegebene Task fertig ist
		Console.WriteLine("Toast fertig");
		//Async Methoden die einen Task zurückgeben, brauchen kein return
	}

	static async Task TasseAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
	}

	static async Task KaffeeAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
	}
	#endregion

	#region Async mit Objekten
	static async Task<Toast> ToastObjectAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast(); //Durch Task<T> muss ein Rückgabewert eingebaut werden
	}

	static async Task<Tasse> TasseObjectAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Tasse fertig");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeObjectAsync(Tasse t) //Zu diesem Zeitpunkt muss der Tasse Task schon fertig sein, dadurch können wir hier ein Tasse Objekt verlangen
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee(t);
	}
	#endregion
}

public class Toast { }

public class Tasse { }

public record Kaffee(Tasse t);

public record Fruehstueck(Toast t, Kaffee k);