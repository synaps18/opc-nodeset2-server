using Opc.NodeSet2.Server.Extensions;
using Opc.NodeSet2.Server.Server;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Services;

/// <inheritdoc />
public class NodeServiceBase : INodeServiceBase
{
	protected readonly InternalNodeManager NodeManager;

	private readonly Dictionary<NodeId, Dictionary<NodeId, GenericMethodCalledEventHandler2>> _methodObjectHandler =
		new();

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="standardServer"></param>
	/// <exception cref="NullReferenceException"></exception>
	public NodeServiceBase(IInternalStandardServer standardServer)
	{
		NodeManager = standardServer.NodeManager ?? throw new NullReferenceException("Node manager is NULL");
	}

	/// <inheritdoc />
	public virtual void Start()
	{
		//Nothing to do here
	}

	protected T GetNodeState<T>(NodeId nodeId)
	{
		if (!NodeManager.FindPredefinedNode<T>(nodeId, out var measuredAmplitudeState))
			throw new KeyNotFoundException("Node id not found!");
		return measuredAmplitudeState!;
	}

	protected void RegisterMethodCalledHandler(NodeId objectId, NodeId methodNodeId,
		GenericMethodCalledEventHandler2 handler)
	{
		if (_methodObjectHandler.TryGetValue(methodNodeId, out var value))
		{
			if (value.TryGetValue(objectId, out _))
				throw new Exception(
					$"Method handler for method '{methodNodeId}' with object '{objectId}' already registered!");

			value[objectId] = handler;
			return;
		}

		var methodNode = GetNodeState<MethodState>(methodNodeId);

		_methodObjectHandler[methodNodeId] = new Dictionary<NodeId, GenericMethodCalledEventHandler2>
			{ { objectId, handler } };

		methodNode.OnCallMethod2 = (context, method, parentId, arguments, outputArguments) =>
		{
			if (_methodObjectHandler[method.NodeId].TryGetValue(parentId, out var handler2))
				return handler2(context, method, objectId, arguments, outputArguments);

			throw new NotImplementedException();
		};
	}

	protected void ReportModelChanged(NodeState source, ModelChangeStructureDataType[] structureData)
	{
		// Erzeuge ein neues ModelChangeEvent
		var modelChangeEvent = new GeneralModelChangeEventState(null);

		// Initialisiere es (Pflicht!)
		modelChangeEvent.Initialize(
			NodeManager.SystemContext,
			source,
			EventSeverity.Low,
			"ModelChangeEvent"
		);

		// Erzeuge die ModelChangeStructure-Daten
		modelChangeEvent.Changes = new PropertyState<ModelChangeStructureDataType[]>(null)
		{
			Value = structureData
		};

		NodeManager.Server.ReportEvent(modelChangeEvent);
	}
}