namespace Multithreading;

internal class _01_ThreadStart
{
	static void Main(string[] args)
	{
		Thread t1 = new Thread(Run); //Legt einen Thread an mit einem Methodenzeiger
		t1.Start(); //Thread starten

		Thread t2 = new Thread(Run); //Legt einen Thread an mit einem Methodenzeiger
		t2.Start(); //Thread starten
		
		Thread t3 = new Thread(Run); //Legt einen Thread an mit einem Methodenzeiger
		t3.Start(); //Thread starten

		//Ab hier Parallel

		t1.Join(); //Warte auf t1, t2 und t3 laufen weiter
		t2.Join(); //Warte auf t2, t3 läuft weiter
		t3.Join(); //Warte auf t3
		//Fahre mit dem Main Thread fort

		for (int i = 0; i < 100; i++)
			Console.WriteLine($"Main Thread: {i}");
	}

	static void Run()
	{
		for (int i = 0; i < 100; i++)
            Console.WriteLine($"Side Thread: {i}");
    }
}