using Microsoft.VisualBasic.FileIO;
using System.Xml;
using System.Xml.Serialization;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//SystemJson();

		//NewtonsoftJson();

		//XML();

		//CSV();
	}

	public static void SystemJson()
	{
		//Path, File, Directory
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		//string folderPath = Path.Combine(desktop, "Test");
		//string filePath = Path.Combine(folderPath, "Test.txt");

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//List<Fahrzeug> fahrzeuge = new()
		//{
		//	new Fahrzeug(0, 251, FahrzeugMarke.BMW),
		//	new Fahrzeug(1, 274, FahrzeugMarke.BMW),
		//	new Fahrzeug(2, 146, FahrzeugMarke.BMW),
		//	new Fahrzeug(3, 208, FahrzeugMarke.Audi),
		//	new Fahrzeug(4, 189, FahrzeugMarke.Audi),
		//	new Fahrzeug(5, 133, FahrzeugMarke.VW),
		//	new Fahrzeug(6, 253, FahrzeugMarke.VW),
		//	new Fahrzeug(7, 304, FahrzeugMarke.BMW),
		//	new Fahrzeug(8, 151, FahrzeugMarke.VW),
		//	new Fahrzeug(9, 250, FahrzeugMarke.VW),
		//	new Fahrzeug(10, 217, FahrzeugMarke.Audi),
		//	new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		//};

		////Teil 2: Modifizieren des Outputs (Options, Attribute)
		//JsonSerializerOptions options = new();
		//options.WriteIndented = true; //Json schön schreiben
		//options.ReferenceHandler = ReferenceHandler.IgnoreCycles; //Kreise ignorieren

		////System.Text.Json
		////Teil 1: Json schreiben und lesen
		//string json = JsonSerializer.Serialize(fahrzeuge, options); //WICHTIG: Options übergeben
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson, options);

		////Teil 3: Json per Hand durchgehen
		////Edit -> Paste Special -> Paste JSON as Classes, Generiert eine Json Struktur als Klassen
		//readJson = File.ReadAllText(Path.Combine(folderPath, "history.city.list.min.json"));
		//JsonDocument doc = JsonDocument.Parse(readJson);
		//foreach (JsonElement element in doc.RootElement.EnumerateArray()) //Aus dem JsonDocument einen Enumerator erzeugen, damit wir dieses Json per Schleife durchgehen können
		//{
		//	string gesamt =
		//		element.GetProperty("city").GetProperty("id").GetProperty("$numberLong").GetString() + " " +
		//		element.GetProperty("city").GetProperty("name").GetString();
		//	Console.WriteLine(gesamt);
		//}
	}

	public static void NewtonsoftJson()
	{
		//Path, File, Directory
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		//string folderPath = Path.Combine(desktop, "Test");
		//string filePath = Path.Combine(folderPath, "Test.txt");

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//List<Fahrzeug> fahrzeuge = new()
		//{
		//	new Fahrzeug(0, 251, FahrzeugMarke.BMW),
		//	new Fahrzeug(1, 274, FahrzeugMarke.BMW),
		//	new Fahrzeug(2, 146, FahrzeugMarke.BMW),
		//	new Fahrzeug(3, 208, FahrzeugMarke.Audi),
		//	new Fahrzeug(4, 189, FahrzeugMarke.Audi),
		//	new Fahrzeug(5, 133, FahrzeugMarke.VW),
		//	new Fahrzeug(6, 253, FahrzeugMarke.VW),
		//	new Fahrzeug(7, 304, FahrzeugMarke.BMW),
		//	new Fahrzeug(8, 151, FahrzeugMarke.VW),
		//	new Fahrzeug(9, 250, FahrzeugMarke.VW),
		//	new Fahrzeug(10, 217, FahrzeugMarke.Audi),
		//	new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		//};

		////SystemJson();

		////Teil 2: Modifizieren des Outputs (Options, Attribute)
		//JsonSerializerSettings options = new();
		//options.Formatting = Formatting.Indented;
		//options.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; //Kreise ignorieren
		//options.TypeNameHandling = TypeNameHandling.Objects; //Vererbung ermöglichen

		////System.Text.Json
		////Teil 1: Json schreiben und lesen
		//string json = JsonConvert.SerializeObject(fahrzeuge, options); //WICHTIG: Options übergeben
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson, options);

		////Teil 3: Json per Hand durchgehen
		////Edit -> Paste Special -> Paste JSON as Classes, Generiert eine Json Struktur als Klassen
		//readJson = File.ReadAllText(Path.Combine(folderPath, "history.city.list.min.json"));
		//JToken doc = JToken.Parse(readJson);
		//foreach (JToken element in doc)
		//{
		//	string gesamt = $"{element["city"]["id"]["$numberLong"].Value<string>()} {element["city"]["name"].Value<string>()}";
		//	Console.WriteLine(gesamt);
		//}
	}

	public static void XML()
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//Teil 1: XML lesen und schreiben
		XmlSerializer serializer = new(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
			serializer.Serialize(sw, fahrzeuge);

		using (StreamReader sr = new(filePath))
		{
			List<Fahrzeug> readFzg = serializer.Deserialize(sr) as List<Fahrzeug>;
		}

		//Teil 2: XML per Hand durchgehen
		XmlDocument document = new XmlDocument();
		document.Load(filePath);

		foreach (XmlElement element in document.DocumentElement.ChildNodes)
		{
			Console.WriteLine(element["ID"].InnerText);
			Console.WriteLine(element["MaxV"].InnerText);
			Console.WriteLine(element["Marke"].InnerText);
			Console.WriteLine("-----------------------");

			//Attribute statt Elementen
			Console.WriteLine(element.Attributes["ID"].InnerText);
			Console.WriteLine(element.Attributes["MaxV"].InnerText);
			Console.WriteLine(element.Attributes["Marke"].InnerText);
			Console.WriteLine("-----------------------");
		}
	}

	public static void CSV()
	{

		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		TextFieldParser tfp = new TextFieldParser(filePath);
		tfp.SetDelimiters(";");
		while (!tfp.EndOfData)
		{
			string[] line = tfp.ReadFields();
			//string[] zu Objekt konvertieren
		}

		List<string> csvLines = new();
		foreach (Fahrzeug f in fahrzeuge)
		{
			csvLines.Add($"{f.ID};{f.MaxV};{f.Marke}");
		}
		File.WriteAllLines(filePath, csvLines);

		foreach (Fahrzeug f in fahrzeuge)
		{
			string csv =
				f.GetType()
				.GetProperties()
				.Aggregate("", (agg, fzg) => agg + fzg.GetValue(f) + ";")
				.TrimEnd(';');
		}
	}
}

//Vererbung herstellen mit System.Text.Json
//[JsonDerivedType(typeof(Fahrzeug), "F")]
//[JsonDerivedType(typeof(PKW), "P")]

//Vererbung herstellen mit XML
//[XmlInclude(typeof(Fahrzeug))]
//[XmlInclude(typeof(PKW))]
public class Fahrzeug
{
	//XML
	//[XmlIgnore]
	//[XmlAttribute]
	public int ID { get; set; }

	//Newtonsoft.Json
	//[JsonIgnore]
	//[JsonProperty("Maximalgeschwindigkeit")]
	public int MaxV { get; set; }

	//System.Text.Json
	//[JsonIgnore]
	//[JsonPropertyName("Maximalgeschwindigkeit")]
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int ID, int MaxV, FahrzeugMarke Marke)
	{
		this.ID = ID;
		this.MaxV = MaxV;
		this.Marke = Marke;
	}

    public Fahrzeug()
    {
        
    }
}

public class PKW : Fahrzeug
{
	public PKW(int ID, int MaxV, FahrzeugMarke Marke) : base(ID, MaxV, Marke)
	{
	}

    public PKW()
    {
        
    }
}

public enum FahrzeugMarke { Audi, BMW, VW }