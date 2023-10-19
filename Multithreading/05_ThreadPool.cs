namespace Multithreading;

internal class _05_ThreadPool
{
	static int Anzahl;

	static void Main(string[] args)
	{
		//Der Main Thread ist ein Vordergrundthread
		//Wenn alle Vordergrundthreads beendet werden, werden die Hintergrundthreads abgebrochen

		for (int i = 0; i < 100; i++)
		{
			ThreadPool.QueueUserWorkItem(Run);
		}

		Thread.Sleep(500); //Alle Threads die hier noch Warten, werden abgebrochen
	}

	static void Run(object o)
	{
		int sleep = Random.Shared.Next(0, 1000);
		Thread.Sleep(sleep);
		Interlocked.Increment(ref Anzahl);
        Console.WriteLine($"Fertig {Anzahl}: {sleep}ms");
    }
}
