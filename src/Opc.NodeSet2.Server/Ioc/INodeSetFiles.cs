namespace Opc.NodeSet2.Server.Ioc;

/// <summary>
/// Represents a collection of file paths associated with a node set.
/// </summary>
public interface INodeSetFiles
{
	/// <summary>
	/// Gets the collection of file paths.
	/// </summary>
	internal HashSet<string> Files { get; }

	/// <summary>
	/// Adds the specified file path to the collection of files.
	/// </summary>
	/// <param name="filePath">The path of the file to add. Cannot be null or empty.</param>
	public void Add(string filePath);
}