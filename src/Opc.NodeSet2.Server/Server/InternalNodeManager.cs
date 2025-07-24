using DryIoc;
using Opc.NodeSet2.Server.Ioc;
using Opc.Ua;
using Opc.Ua.Export;
using Opc.Ua.Server;

namespace Opc.NodeSet2.Server.Server
{
	/// <summary>
	///     Manages internal OPC UA nodes and their predefined configurations, extending the functionality of
	///     <see
	///         cref="CustomNodeManager2" />
	///     .
	/// </summary>
	public class InternalNodeManager : CustomNodeManager2
	{
		private readonly IContainer _container;

		/// <summary>
		///     Constructor
		/// </summary>
		/// <param name="server"></param>
		/// <param name="configuration"></param>
		/// <param name="container"></param>
		public InternalNodeManager(IServerInternal server, ApplicationConfiguration configuration,
			IContainer container)
			: base(server, configuration)
		{
			_container = container;

			var encodeableTypes = _container.Resolve<IEncodeableTypes>();

			foreach (var assembly in encodeableTypes.Assemblies) Server.Factory.AddEncodeableTypes(assembly);

			Server.Factory.AddEncodeableTypes(encodeableTypes.Types);
		}

		/// <summary>
		///     Gets the dictionary of predefined nodes for the server.
		/// </summary>
		public new NodeIdDictionary<NodeState> PredefinedNodes => base.PredefinedNodes;

		/// <summary>
		///     Adds a predefined node to the server's address space.
		/// </summary>
		/// <param name="context">The system context used to manage the operation. Cannot be <see langword="null" />.</param>
		/// <param name="node">The node to add to the address space. Cannot be <see langword="null" />.</param>
		public new void AddPredefinedNode(ISystemContext context, NodeState node)
		{
			base.AddPredefinedNode(context, node);
		}

		private void ImportXml(IDictionary<NodeId, IList<IReference>> externalReferences, string resourcePath)
		{
			try
			{
				var predefinedNodes = new NodeStateCollection();

				using Stream stream = new FileStream(resourcePath, FileMode.Open);
				var nodeSet = UANodeSet.Read(stream);

				nodeSet.Import(SystemContext, predefinedNodes);

				// Detect new namespace uris imported from file
				var newNamespaceUris = new List<string>();
				if (nodeSet.NamespaceUris != null && SystemContext.NamespaceUris != null)
					foreach (var namespaceUri in nodeSet.NamespaceUris)
					{
						SystemContext.NamespaceUris.GetIndexOrAppend(namespaceUri);
						newNamespaceUris.Add(namespaceUri);
					}

				// Add new namespace uris to current node manager
				if (newNamespaceUris.Count > 0)
				{
					var allNamespaceUris = new List<string>();
					allNamespaceUris.AddRange(NamespaceUris);
					allNamespaceUris.AddRange(newNamespaceUris);
					SetNamespaces(allNamespaceUris.ToArray());

					foreach (var namespaceUri in newNamespaceUris)
						Server.NodeManager.RegisterNamespaceManager(namespaceUri, this);
				}

				// Add new imported nodes to the predefined nodes collection
				foreach (var predefinedNode in predefinedNodes) AddPredefinedNode(SystemContext, predefinedNode);

				// Ensure the reverse references exist.
				AddReverseReferences(externalReferences);
			}
			catch (Exception)
			{
				// ignored
			}
		}


		protected override void LoadPredefinedNodes(ISystemContext context,
			IDictionary<NodeId, IList<IReference>> externalReferences)
		{
			base.LoadPredefinedNodes(context, externalReferences);

			var nodeSetFiles = _container.Resolve<INodeSetFiles>();
			foreach (var nodeSetPath in nodeSetFiles.Files) ImportXml(externalReferences, nodeSetPath);
		}
	}
}