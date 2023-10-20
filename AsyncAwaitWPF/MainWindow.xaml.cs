using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//ProgressBar füllen von 0 bis 100 in 25ms Abständen (2.5s)
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Progress.Value++;
			Thread.Sleep(25); //Blockiert den Main Thread (UI Thread)
		}
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Task.Run(() =>
		{
			Dispatcher.Invoke(() => Progress.Value = 0); //Threads/Tasks dürfen nicht auf den UI Thread zugreifen
			for (int i = 0; i < 100; i++)
			{
				Dispatcher.Invoke(() => Progress.Value++); //Mit dem Dispatcher eine Action auf den UI Thread legen
				Thread.Sleep(25);
			}
		});
	}

	private async void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Progress.Value++;
			await Task.Delay(25);
		}
	}

	private async void Button1_Click(object sender, RoutedEventArgs e)
	{
		//Request starten und UI Updates geben
		using HttpClient httpClient = new HttpClient();
		Task<HttpResponseMessage> resp = httpClient.GetAsync("http://www.gutenberg.org/files/54700/54700-0.txt"); //Hier Request starten
		
		//UI Updates
		TB.Text = "Request gestartet";
		Progress.Value = 33;
		Button1.IsEnabled = false;

		HttpResponseMessage message = await resp; //Ab hier auf das Ergebnis warten

		if (message.IsSuccessStatusCode)
		{
			Task<string> content = message.Content.ReadAsStringAsync();
			
			//UI Updates
			TB.Text = "Response wird ausgelesen...";
			Progress.Value = 66;

			await Task.Delay(1500);
			string text = await content;

			Progress.Value = Progress.Maximum;
			Button1.IsEnabled = true;
			TB.Text = text;
		}
	}

	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
		string output = Enumerable.Range(0, 10_000_000).Aggregate(new StringBuilder(), (agg, str) => agg.AppendLine(str.ToString())).ToString();
		List<string> outputs = Enumerable.Repeat(output, 50).ToList();

		if (Directory.Exists("Outputs"))
			Directory.Delete("Outputs", true);
		if (!Directory.Exists("Outputs"))
			Directory.CreateDirectory("Outputs");

		//await Parallel.ForEachAsync(outputs, (str, ct) =>
		//{
		//	string fileName = Random.Shared.Next().ToString();
		//	File.WriteAllText($@"Outputs\{fileName}.txt", str);
		//	Dispatcher.Invoke(() => TB.Text += $"File geschrieben: {fileName}\n");
		//	return ValueTask.CompletedTask;
		//});

		foreach (string text in outputs)
			await File.WriteAllTextAsync($@"Outputs\{Random.Shared.Next()}.txt", text);
	}
}
