namespace Multitasking;

internal class _02_TaskMitReturn
{
	static void Main(string[] args)
	{
		Task<int> intTask = new Task<int>(RunInt);
		intTask.Start();

        Console.WriteLine(intTask.Result); //Ergebnis entnehmen wenn der Task fertig ist
		//Result blockiert den Main Thread

		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");

		Task t2 = Task.Run(() => Console.WriteLine("Anonyme Methode im Task"));

		Task t3 = Task.Run(() =>
		{
            Console.WriteLine("Mehrzeilige");
            Console.WriteLine("anonyme");
            Console.WriteLine("Methode");
        });

		//Auf Tasks warten

		t2.Wait(); //Wartet auf den Task, blockiert den Main Thread
		Task.WaitAll(intTask, t2, t3); //Wartet auf alle gegebenen Tasks, blockiert den Main Thread
		Task.WaitAny(intTask, t2, t3); //Wartet auf einen gegebenen Task, gibt den Index des ersten fertig gewordenen Tasks zurück, blockiert den Main Thread
	}

	static int RunInt()
	{
		Thread.Sleep(500);
		return Random.Shared.Next();
	}
}
