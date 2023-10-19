namespace Multitasking;

internal class _01_TaskStarten
{
	static void Main(string[] args)
	{
		Task t = new Task(Run); //Task liegt am ThreadPool -> Hintergrundthread
		t.Start();

		Task t2 = Task.Factory.StartNew(Run); //Ab .NET 4.0

		Task t3 = Task.Run(Run); //Ab .NET 4.5

		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");

		Console.ReadKey(); //Main Thread blockieren
	}

	static void Run()
	{
		for (int i = 0; i < 1000; i++)
            Console.WriteLine($"Side Task: {i}");
    }
}