using DryIoc;
using Opc.NodeSet2.Server.Services;

namespace Opc.NodeSet2.Server.Ioc;

/// <inheritdoc />
public class NodeServiceContainer : INodeServiceContainer
{
	private readonly IContainer _container;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="container"></param>
	public NodeServiceContainer(IContainer container)
	{
		_container = container;
	}

	/// <inheritdoc />
	public void Register<T>() where T : INodeServiceBase
	{
		_container.Register<INodeServiceBase, T>();
	}
}