namespace PluginBase;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ReflectionVisible : Attribute
{
	public string Name { get; set; }

    public ReflectionVisible(string name)
    {
		Name = name;
    }
}
