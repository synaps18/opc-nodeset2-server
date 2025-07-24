namespace Opc.NodeSet2.Server.Ioc;

/// <inheritdoc />
public class NodeSetFiles : INodeSetFiles
{
	/// <inheritdoc />
	public HashSet<string> Files { get; } = [];

	/// <inheritdoc />
	public void Add(string filePath)
	{
		Files.Add(filePath);
	}
}