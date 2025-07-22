using Opc.NodeSet2.Server.Server;
using Opc.NodeSet2.Server.Services;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Example.NodeServices;

/// <summary>
/// Enables Read and Write permissions for all predefined nodes
/// </summary>
public class EnableReadWriteOnAllBaseVariableStatesNodeService : NodeServiceBase
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="server"></param>
	public EnableReadWriteOnAllBaseVariableStatesNodeService(IInternalStandardServer server) : base(server)
	{
	}

	/// <inheritdoc />
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