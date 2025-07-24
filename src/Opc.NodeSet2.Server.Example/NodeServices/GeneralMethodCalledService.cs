using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Example.NodeServices;

public class GeneralMethodCalledService : NodeServiceBase
{
	public GeneralMethodCalledService(IInternalStandardServer standardServer) : base(standardServer)
	{
	}

	public override void Start()
	{
		base.Start();

		//Give full access to all variable nodes!
		foreach (var predefinedNode in NodeManager.PredefinedNodes.Where(a => a.Value is MethodState)
			         .Select(a => a.Value as MethodState))
		{
			if (predefinedNode is null) continue;

			predefinedNode.OnCallMethod2 += OnCallMethod2;
		}
	}

	private ServiceResult OnCallMethod2(ISystemContext context, MethodState method, NodeId objectId, IList<object> inputArguments, IList<object> outputArguments)
	{
		try
		{
			var objectState = GetNodeState<BaseObjectState>(objectId);
			Console.WriteLine($"Method '{method.DisplayName}' with node id '{method.NodeId}' called! Parent object is '{objectState.DisplayName}' with node id '{objectId}'");
		}
		catch (Exception)
		{
			Console.WriteLine($"Method '{method.DisplayName}' with node id '{method.NodeId}' called! Parent object with node id '{objectId}' not found!");
		}

		return ServiceResult.Good;
	}
}