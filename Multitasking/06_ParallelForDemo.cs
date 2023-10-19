using System.Diagnostics;

namespace Multitasking;

internal class _06_ParallelForDemo
{
	static void Main(string[] args)
	{
		int[] durchgänge = { 1000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };
		for (int i = 0; i < durchgänge.Length; i++)
		{
			int d = durchgänge[i];

			Stopwatch sw = Stopwatch.StartNew();
			RegularFor(d);
			sw.Stop();
			Console.WriteLine($"For Durchgänge: {d}, {sw.ElapsedMilliseconds}ms");

			Stopwatch sw2 = Stopwatch.StartNew();
			ParallelFor(d);
			sw2.Stop();
			Console.WriteLine($"ParallelFor Durchgänge: {d}, {sw2.ElapsedMilliseconds}ms");

            Console.WriteLine("------------------------------------------------------------");
        }

		/*
			For Durchgänge: 1000, 0ms
			ParallelFor Durchgänge: 1000, 36ms
			For Durchgänge: 10000, 1ms
			ParallelFor Durchgänge: 10000, 7ms
			For Durchgänge: 50000, 10ms
			ParallelFor Durchgänge: 50000, 10ms
			For Durchgänge: 100000, 20ms
			ParallelFor Durchgänge: 100000, 27ms
			For Durchgänge: 250000, 65ms
			ParallelFor Durchgänge: 250000, 17ms
			For Durchgänge: 500000, 129ms
			ParallelFor Durchgänge: 500000, 87ms
			For Durchgänge: 1000000, 273ms
			ParallelFor Durchgänge: 1000000, 82ms
			For Durchgänge: 5000000, 2161ms
			ParallelFor Durchgänge: 5000000, 482ms
			For Durchgänge: 10000000, 2402ms
			ParallelFor Durchgänge: 10000000, 548ms
			For Durchgänge: 100000000, 24527ms
			ParallelFor Durchgänge: 100000000, 9612ms
		 */
	}

	static void RegularFor(int iterations)
	{
		double[] erg = new double[iterations];
		for (int i = 0; i < iterations; i++)
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
	}

	static void ParallelFor(int iterations)
	{
		double[] erg = new double[iterations];
		//int i = 0; i < iterations; i++
		Parallel.For(0, iterations, i =>
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100));
	}
}
