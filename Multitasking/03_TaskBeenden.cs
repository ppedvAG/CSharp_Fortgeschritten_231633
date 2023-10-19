namespace Multitasking;

internal class _03_TaskBeenden
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new();
		CancellationToken token = cts.Token;

		Task t = new Task(Run, token);
		t.Start();

		Thread.Sleep(500);

		cts.Cancel();
	}

	static void Run(object o)
	{
		if (o is CancellationToken ct)
		{
			for (int i = 0; i < 100; i++)
			{
                Console.WriteLine($"Side Task: {i}");
				Thread.Sleep(25);
				ct.ThrowIfCancellationRequested(); //Task wirft Exception, aber diese ist nicht sichtbar
            }
		}
	}
}
