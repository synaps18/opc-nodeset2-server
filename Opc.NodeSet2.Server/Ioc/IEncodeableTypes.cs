using System.Reflection;

namespace Opc.NodeSet2.Server.Ioc;

/// <summary>
///     Represents a collection of types and assemblies that can be encoded or processed in a specific context.
/// </summary>
public interface IEncodeableTypes
{
	/// <summary>
	///     Gets the collection of assemblies associated with the current context.
	/// </summary>
	internal HashSet<Assembly> Assemblies { get; }

	/// <summary>
	///     Gets the collection of unique <see cref="Type" /> objects associated with this instance.
	/// </summary>
	internal HashSet<Type> Types { get; }

	/// <summary>
	///     Adds the specified type to the collection.
	/// </summary>
	/// <param name="type">The type to add to the collection. Cannot be <see langword="null" />.</param>
	void Add(Type type);

	/// <summary>
	///     Adds the specified assembly to the collection of assemblies.
	/// </summary>
	/// <param name="assembly">The assembly to add. Cannot be <see langword="null" />.</param>
	void Add(Assembly assembly);
}