using DryIoc;
using Opc.Ua;
using Opc.Ua.Server;

namespace Opc.NodeSet2.Server.Server
{
	/// <summary>
	///     Represents an internal implementation of a standard server that integrates with a dependency injection container.
	/// </summary>
	public class InternalStandardServer : StandardServer, IInternalStandardServer
	{
		private readonly IContainer _container;

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="container"></param>
		public InternalStandardServer(IContainer container)
		{
			_container = container;
		}

		/// <summary>
		///     Gets the internal node manager responsible for managing nodes within the system.
		/// </summary>
		public InternalNodeManager? NodeManager { get; private set; }

		protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server,
			ApplicationConfiguration config)
		{
			var nodeManagers = new List<INodeManager>
			{
				(NodeManager = new InternalNodeManager(server, config, _container))
			};

			return new MasterNodeManager(server, config, null, nodeManagers.ToArray());
		}

	}
}