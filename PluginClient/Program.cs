using PluginBase;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace PluginClient;

internal class Program
{
	static void Main(string[] args)
	{
		Assembly a = Assembly.LoadFrom(@"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2023_10_16\PluginCalculator\bin\Debug\net7.0\PluginCalculator.dll");

		Type pluginType = a.DefinedTypes.First(e => e.GetInterfaces().Contains(typeof(IPlugin)));

		IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;

		foreach (PropertyInfo prop in pluginType.GetProperties())
		{
            Console.WriteLine($"{prop.Name}: {prop.GetValue(plugin)}");
        }

		MethodInfo[] methods = pluginType.GetMethods().Where(e => e.GetCustomAttribute<ReflectionVisible>() != null).ToArray();
		for (int i = 0; i < methods.Length; i++)
		{
			ReflectionVisible attr = methods[i].GetCustomAttribute<ReflectionVisible>();
			string name = attr.Name;
			Console.WriteLine($"{i + 1}: {name}");
        }
	}
}