using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Example.NodeServices;

/// <summary>
/// Handles example method calls
/// </summary>
public class MethodHandleService : NodeServiceBase
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="standardServer"></param>
	public MethodHandleService(IInternalStandardServer standardServer) : base(standardServer)
	{

	}

	public override void Start()
	{
		base.Start();

		var demoObjectNodeId = ExpandedNodeId.ToNodeId(NodeSet2Server.ObjectIds.Demo, NodeManager.Server.NamespaceUris);
		var callMeMethodNodeId = NodeId.Parse("ns=3;i=7000");
		var callMe2MethodNodeId = NodeId.Parse("ns=3;i=7001");

		RegisterMethodCalledHandler(demoObjectNodeId, callMeMethodNodeId, Demo_OnCallMeCalled);
		RegisterMethodCalledHandler(demoObjectNodeId, callMe2MethodNodeId, Demo_OnCallMe2Called);
	}

	private ServiceResult Demo_OnCallMe2Called(ISystemContext context, MethodState method, NodeId objectId, IList<object> inputArguments, IList<object> outputArguments)
	{
		Console.WriteLine("CallMe2 Called");
		return ServiceResult.Good;
	}

	private ServiceResult Demo_OnCallMeCalled(ISystemContext context, MethodState method, NodeId objectId, IList<object> inputArguments, IList<object> outputArguments)
	{
		Console.WriteLine("CallMe Called");
		return ServiceResult.Good;
	}
}