namespace TPL_Uebung;

public class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.WriteLine("Eingaben: ");
			Console.WriteLine("1: Neuen Scanner erstellen");
			Console.WriteLine("2: Anzahl Worker Tasks anpassen");
			Console.WriteLine("3: Speicherpfad anpassen");
			Console.WriteLine("4: Prozess starten/fortsetzen");
			Console.WriteLine("5: Prozess pausieren");

			ConsoleKey inputKey = Console.ReadKey(true).Key;

			switch (inputKey)
			{
				case ConsoleKey.D1:
					CreateScanner();
					break;

				case ConsoleKey.D2:
					AdjustWorkerAmount();
					break;

				case ConsoleKey.D3:
					AdjustOutputPath();
					break;

				case ConsoleKey.D4:
					StartProcess();
					break;

				case ConsoleKey.D5:
					PauseProcess();
					break;
			}
		}
	}

	#region Input Methoden
	private static void CreateScanner()
	{

	}

	private static void AdjustWorkerAmount()
	{

	}

	private static void AdjustOutputPath()
	{

	}

	private static void StartProcess()
	{

	}

	private static void PauseProcess()
	{

	}
	#endregion

	/// <summary>
	/// Diese Methode soll in der Worker Klasse implementiert werden.
	/// Diese Methode simuliert eine länger andauernde Arbeit (hier Bildverarbeitung) die mit paralleler Programmierung durchgeführt werden soll.
	/// Diese Methode nimmt ein gegebenes Image des Parameters loadPath und liest es ein.
	/// Danach wird das Image in Graustufen neu erzeugt und im Ordner savePath gespeichert.
	/// </summary>
	//[SupportedOSPlatform("windows")] //Warnings entfernen
	//private void ProcessImage(string loadPath, string savePath)
	//{
	//	Bitmap img = new Bitmap(loadPath);
	//	Bitmap output = new Bitmap(img.Width, img.Height);
	//	for (int i = 0; i < img.Width; i++)
	//	{
	//		for (int j = 0; j < img.Height; j++)
	//		{
	//			Color currentPixel = img.GetPixel(i, j);
	//			int grayScale = (int) (currentPixel.R * 0.3 + currentPixel.G * 0.59 + currentPixel.B * 0.11);
	//			Color newColor = Color.FromArgb(currentPixel.A, grayScale, grayScale, grayScale);
	//			output.SetPixel(i, j, newColor);
	//		}
	//	}
	//	output.Save(savePath); //Dateiname nicht vergessen
	//}
}