using NodeSet2Server;
using Opc.NodeSet2.Server.Extensions;
using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;
using ObjectIds = NodeSet2Server.ObjectIds;

namespace Opc.NodeSet2.Server.Example.NodeServices;

/// <summary>
///     Handles example method calls
/// </summary>
public class MethodHandleService : NodeServiceBase
{
	private int _cnt;

	/// <summary>
	///     Constructor
	/// </summary>
	/// <param name="standardServer"></param>
	public MethodHandleService(IInternalStandardServer standardServer) : base(standardServer)
	{
	}

	public override void Start()
	{
		base.Start();

		var demoObjectNodeId = ExpandedNodeId.ToNodeId(ObjectIds.Demo, NodeManager.Server.NamespaceUris);
		var helloWorldMethodNodeId = NodeId.Parse("ns=3;i=7000");
		var createDemoStructureMethodNodeId = NodeId.Parse("ns=3;i=7001");
		var validateDemoStructureMethodNodeId = NodeId.Parse("ns=3;i=7002");

		RegisterMethodCalledHandler(demoObjectNodeId, helloWorldMethodNodeId, Demo_OnHelloWorldCalled);
		RegisterMethodCalledHandler(demoObjectNodeId, createDemoStructureMethodNodeId, Demo_OnCreateDemoStructureCalled);
		RegisterMethodCalledHandler(demoObjectNodeId, validateDemoStructureMethodNodeId, Demo_OnValidateDemoStructureCalled);
	}

	private ServiceResult Demo_OnCreateDemoStructureCalled(ISystemContext context, MethodState method, NodeId objectId,
		IList<object> inputArguments, IList<object> outputArguments)
	{
		var newStructure = new DemoStructure
		{
			Id = ++_cnt,
			Name = inputArguments[0] as string ?? string.Empty
		};

		outputArguments[0] = newStructure;

		var latestDemoStructureState = GetNodeState<BaseDataVariableState>("ns=3;i=6016");
		latestDemoStructureState.Publish(newStructure, NodeManager.SystemContext);

		var allDemoStructuresState = GetNodeState<BaseDataVariableState>("ns=3;i=6017");
		if (allDemoStructuresState.Value is not ExtensionObject[] allStructures)
		{
			allStructures = [];
		};

		var newStructures = new List<ExtensionObject>(allStructures) { new (newStructure) };

		allDemoStructuresState.Publish(newStructures.ToArray(), NodeManager.SystemContext);

		return ServiceResult.Good;
	}

	private ServiceResult Demo_OnHelloWorldCalled(ISystemContext context, MethodState method, NodeId objectId,
		IList<object> inputArguments, IList<object> outputArguments)
	{
		outputArguments[0] = "Hello World!";
		return ServiceResult.Good;
	}

	private ServiceResult Demo_OnValidateDemoStructureCalled(ISystemContext context, MethodState method,
		NodeId objectId, IList<object> inputArguments, IList<object> outputArguments)
	{
		if (inputArguments[0] is not DemoStructure demoStructure) outputArguments[0] = false;

		outputArguments[0] = true;
		return ServiceResult.Good;
	}
}