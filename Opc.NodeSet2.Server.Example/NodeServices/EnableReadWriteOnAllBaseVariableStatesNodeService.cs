using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Example.NodeServices;

public class EnableReadWriteOnAllBaseVariableStatesNodeService : NodeServiceBase
{
	public EnableReadWriteOnAllBaseVariableStatesNodeService(IInternalStandardServer server) : base(server)
	{
	}

	public override void Start()
	{
		//Give full access to all variable nodes!
		foreach (var predefinedNode in NodeManager.PredefinedNodes.Where(a => a.Value is BaseVariableState)
			         .Select(a => a.Value as BaseVariableState))
		{
			if (predefinedNode is null) continue;

			predefinedNode.AccessLevel = AccessLevels.CurrentReadOrWrite;
			predefinedNode.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
		}
	}
}