namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		//Task<double> t1 = new Task<double>(() => //Task.Run und ContinueWith sollten nicht kombiniert werden, da der Task schneller fertig sein könnte als ContinueWith ausgeführt wird -> Kein Folgetask
		//{
		//	Thread.Sleep(1000);
		//	return Math.Pow(4, 23);
		//});
		//t1.ContinueWith(vorherigerTask => Console.WriteLine(vorherigerTask.Result));
		//t1.Start();
		////Verkettung erstellt: Wenn t1 fertig -> t2 starten
		////Wenn t1 fertig ist, kann in dem Folgetask auf den vorherigen Task zugegriffen werden

		////Console.WriteLine(t1.Result); //Blockiert

		//for (int i = 0; i < 100; i++)
		//{
		//	Console.WriteLine($"Main Thread: {i}");
		//	Thread.Sleep(25);
		//}

		/////////////////////////////////////////////////////

		//Taskabzweigungen
		Task<int> t2 = new Task<int>(() =>
		{
			Thread.Sleep(500);
			throw new Exception();
			return Random.Shared.Next();
		});
		t2.ContinueWith(vorherigerTask => Console.WriteLine(vorherigerTask.Result)); //Result Task
		t2.ContinueWith(vorherigerTask => Console.WriteLine("Erfolg"), TaskContinuationOptions.OnlyOnRanToCompletion); //Erfolgstask, dieser Task soll nur ausgeführt werden, wenn der vorherige Task fehlerfrei durchgelaufen ist
		t2.ContinueWith(t => Console.WriteLine($"Fehler: {t.Exception.InnerException.StackTrace}"), TaskContinuationOptions.OnlyOnFaulted); //Fehler Task, soll nur ausgeführt werden, wenn eine Exception im vorherigen Task aufgetreten ist
		t2.Start();

		//Bei Erfolg werden die ersten beiden Verkettungen ausgeführt
		Console.ReadKey();
	}
}
