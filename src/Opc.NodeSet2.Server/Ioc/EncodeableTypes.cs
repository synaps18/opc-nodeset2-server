using System.Reflection;

namespace Opc.NodeSet2.Server.Ioc;

/// <inheritdoc />
public class EncodeableTypes : IEncodeableTypes
{
	/// <inheritdoc />
	public HashSet<Assembly> Assemblies { get; } = [];

	/// <inheritdoc />
	public HashSet<Type> Types { get; } = [];

	/// <inheritdoc />
	public void Add(Type type)
	{
		Types.Add(type);
	}

	/// <inheritdoc />
	public void Add(Assembly assembly)
	{
		Assemblies.Add(assembly);
	}
}