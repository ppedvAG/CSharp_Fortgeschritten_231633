namespace Multithreading;

internal class _04_CancellationToken
{
	static void Main(string[] args)
	{
		try
		{
			CancellationTokenSource cts = new CancellationTokenSource(); //Sender, Aussteller
			CancellationToken token = cts.Token; //Der Token (struct), wird neu erstellt wenn aus der Source ein Token entnommen wird

			Thread t = new Thread(Run);
			t.Start(token);

			Thread.Sleep(500);

			cts.Cancel(); //Auf der Source allen Tokens das Signal zum Canceln senden
		}
		catch (OperationCanceledException ex) //Exception kann nicht hier oben gefangen werden
		{
            Console.WriteLine(ex.Message);
        }
	}

	static void Run(object o)
	{
		try
		{
			if (o is CancellationToken ct)
			{
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine($"Side Thread: {i}");
					Thread.Sleep(25);
					ct.ThrowIfCancellationRequested();
				}
			}
		}
		catch (OperationCanceledException ex) //Exception muss hier unten gefangen werden
		{
            Console.WriteLine(ex.Message);
        }
	}
}
