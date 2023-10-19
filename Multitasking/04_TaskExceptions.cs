namespace Multitasking;

internal class _04_TaskExceptions
{
	static void Main(string[] args)
	{
		Task t1 = Task.Run(Run);
		Task t2 = Task.Run(Run);
		Task t3 = Task.Run(Run);

		Task<int> t4 = Task.Run<int>(() => 0);
        Console.WriteLine(t4.Result); //Wirft auch AggregateException

        try
		{
			Task.WaitAll(t1, t2, t3); //Bei WaitAll und Wait wird die AggregateException geworfen, diese enthält alle gefangenen Exceptions
		}
		catch (AggregateException ex)
		{
			foreach (Exception e in ex.InnerExceptions) //Liste von Exceptions
                Console.WriteLine(e.Message);
        }
	}

	static void Run()
	{
		Thread.Sleep(Random.Shared.Next(1000, 10000));
        Console.WriteLine("Hier kommt die Exception: ");
        throw new InvalidOperationException();
	}
}
