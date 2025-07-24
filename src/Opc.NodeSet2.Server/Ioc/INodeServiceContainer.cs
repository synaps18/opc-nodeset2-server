using Opc.NodeSet2.Server.Services;

namespace Opc.NodeSet2.Server.Ioc;

/// <summary>
/// Provides a container for managing and registering node services that implement <see cref="INodeServiceBase"/>.
/// </summary>
public interface INodeServiceContainer
{
	/// <summary>
	/// Registers a service of type <typeparamref name="T"/> as an implementation of <see cref="INodeServiceBase"/>.
	/// </summary>
	/// <typeparam name="T">The type of the service to register. Must implement <see cref="INodeServiceBase"/>.</typeparam>
	void Register<T>() where T : INodeServiceBase;
}