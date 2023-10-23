namespace PluginBase;

/// <summary>
/// Dieses Interface stellt die Basis unserer Plugins dar
/// Diese Klassenbibliothek wird als Referenz bei den Plugins und dem Client hinzugefügt
/// </summary>
public interface IPlugin
{
	public string Name { get; }

	public string Description { get; }

	public string Version { get; }

	public string Author { get; }
}