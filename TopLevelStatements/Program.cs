//Console.WriteLine(args);

List<string> list = new List<string>();
//Lege eine String-Liste an und fülle diese mit ein paar Zahlen
//Verwende die ForEach Funktion mit Parse um alle Zahlen in eine Int-Liste zu füllen

//Verwende die vorherige Int-Liste um alle Zahlen zu entfernen die durch 3 oder 5 teilbar sind
//Verwende hierfür die RemoveAll Funktion




Console.WriteLine
(
	Enumerable
	.Range(2, 10000 - 2)
	.GroupBy(e => !Enumerable
		.Range(2, (int) (Math.Ceiling(e / 2d + 1) - 2))
		.Where(x => x % 2 != 0)
		.Append(2)
		.Any(x => e % x == 0 && e != 2))
	.SelectMany(e => e.Select((x, i) => new Tuple<int, bool?>(x, (i + 1) % 100 == 0 && e.Key && i != 0 ? null : e.Key)))
	.OrderBy(e => e.Item1)
	.Aggregate(new System.Text.StringBuilder(), (agg, kv) =>
		agg.AppendLine($"{(kv.Item2 == false ? "Keine " : kv.Item2 == null ? "Hundertste " : "")}Primzahl: {kv.Item1}"))
	.ToString()
);




Enumerable
.Range(2, 10000 - 2)
.GroupBy(e => !Enumerable
	.Range(2, (int) (Math.Ceiling(e / 2d + 1) - 2))
	.Where(x => x % 2 != 0)
	.Append(2)
	.Any(x => e % x == 0 && e != 2))
.SelectMany(e => e.Select((x, i) => new Tuple<int, bool?>(x, (i + 1) % 100 == 0 && e.Key && i != 0 ? null : e.Key)))
.OrderBy(e => e.Item1)
.Aggregate("", (agg, kv) => 
{
	Console.WriteLine($"{(kv.Item2 == false ? "Keine " : kv.Item2 == null ? "Hundertste " : "")}Primzahl: {kv.Item1}");
	Thread.Sleep(50);
	return "";
});