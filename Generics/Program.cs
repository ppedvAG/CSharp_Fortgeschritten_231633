namespace Generics;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new List<string>(); //T wird durch string ersetzt
		list.Add("Ein Text"); //string item statt T item

		Dictionary<string, int> dict = new();
		dict.Add("Text", 1);
	}
}

public class DataStore<T> : IProgress<T>
{
	public T[] data;

	public List<T> Data => data.ToList();

	public void Add(T item, int index)
	{
		if (index >= 0 && index < data.Length)
		{
			data[index] = item;
		}
	}

	public T Get(int index)
	{
		if (index >= 0 && index < data.Length)
			return data[index];
		return default;
	}

	public void Report(T value)
	{
		throw new NotImplementedException();
	}

	public void Test()
	{
        Console.WriteLine(typeof(T));
        Console.WriteLine(default(T)); //Gibt den Standardwert des Typens zurück (int: 0, string: null, bool: false, ...)
        Console.WriteLine(nameof(T)); //Gibt den Typen als String zurück (z.B. "int", "bool", "Program", ...)

		MethodeMitGeneric<T>();
		MethodeMitGeneric<int>();
    }

	public void MethodeMitGeneric<T2>()
	{

	}
}