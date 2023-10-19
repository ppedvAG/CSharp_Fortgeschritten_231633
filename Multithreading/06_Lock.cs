namespace Multithreading;

internal class _06_Lock
{
	static int Counter = 1;

	static object LockObject = new object();

	static void Main(string[] args)
	{
		//Thread 1: i++
		//Thread 2: i++
		//Thread 1 und 2 machen zur exakt selben Zeit i++
		//-> Thread 1 blockt den Speicherbereich von i, dadurch kann T2 i++ nicht ausführen
		//-> Locking

		List<Thread> threads = new List<Thread>();
		for (int i = 0; i < 100; i++)
			threads.Add(new Thread(Run));
		threads.ForEach(e => e.Start());
	}

	static void Run()
	{
		for (int i = 0; i < 1000; i++)
		{
			lock (LockObject) //Lock auf das LockObject legen, dadurch Threads vor dem Lock stoppen bis das Lock wieder freigegeben wird
			{
				Counter++;
				if (Counter % 100 == 0)
					Console.WriteLine(Counter);
			}

			Monitor.Enter(LockObject); //Monitor und Lock haben 1:1 den selben Code darunter
			Counter++;
			if (Counter % 100 == 0)
				Console.WriteLine(Counter);
			Monitor.Exit(LockObject);
		}
	}
}
