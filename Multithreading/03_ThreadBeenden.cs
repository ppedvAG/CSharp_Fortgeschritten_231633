namespace Multithreading;

internal class _03_ThreadBeenden
{
	static void Main(string[] args)
	{
		try
		{
			Thread t = new Thread(Run);
			t.Start();

			//t.Abort(); //PlatformNotSupportedException

			Thread.Sleep(500);

			t.Interrupt();
		}
		catch (ThreadInterruptedException ex) //Exception kann nicht hier oben gefangen werden
		{
			Console.WriteLine(ex.Message);
		}
	}

	static void Run()
	{
		try
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine($"Side Thread: {i}");
				Thread.Sleep(25);
			}
		}
		catch (ThreadInterruptedException ex) //Exception muss hier unten gefangen werden
		{
			Console.WriteLine(ex.Message);
		}
	}
}
