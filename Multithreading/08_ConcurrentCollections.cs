using System.Collections.Concurrent;

namespace Multithreading;

internal class _08_ConcurrentCollections
{
	static void Main(string[] args)
	{
		ConcurrentBag<int> ints = new ConcurrentBag<int>();
		ints.Add(1);
		//ints[] //Hat keinen Index

		ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();

		SynchronizedCollection<int> list = new();
		//list[1]
	}
}
