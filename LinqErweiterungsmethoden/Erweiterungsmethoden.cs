using System.Text;

namespace LinqErweiterungsmethoden;

public static class Erweiterungsmethoden
{
	public static int Quersumme(this int x)
	{
		return x.ToString().Sum(x => (int) char.GetNumericValue(x));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}

	public static string AsString<T>(this IEnumerable<T> x)
	{
		StringBuilder sb = new();
		sb.Append('[');
		//sb.Append(string.Join(',', x.Select(x => x.ToString())));
		sb.Append(x.Aggregate(new StringBuilder(), (sb, item) => sb.Append(item).Append(", ")).ToString().TrimEnd(',', ' '));
		sb.Append(']');
		return sb.ToString();
	}

	public static string AsString<TElement, TSelector>(this IEnumerable<TElement> x, Func<TElement, TSelector> selector)
	{
		StringBuilder sb = new();
		sb.Append('[');
		sb.Append(string.Join(", ", x.Select(x => selector(x))));
		//sb.Append(x.Aggregate(new StringBuilder(), (sb, item) => sb.Append(selector(item)).Append(", ")).ToString().TrimEnd(',', ' '));
		sb.Append(']');
		return sb.ToString();
	}
}
