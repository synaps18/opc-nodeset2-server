using Opc.NodeSet2.Server.Server;
using Opc.Ua;

namespace Opc.NodeSet2.Server.Services;

/// <summary>
///     Applies the missing argument to all available nodes
/// </summary>
public class ApplyMethodArguments : NodeServiceBase
{
	/// <summary>
	///     Constructor
	/// </summary>
	/// <param name="standardServer"></param>
	public ApplyMethodArguments(IInternalStandardServer standardServer) : base(standardServer)
	{
	}

	/// <inheritdoc />
	public override void Start()
	{
		base.Start();

		var inputArguments = NodeManager.PredefinedNodes.Where(a =>
			a.Value.BrowseName == BrowseNames.InputArguments || a.Value.BrowseName == BrowseNames.OutputArguments);

		foreach (var inputArgument in inputArguments)
		{
			if (inputArgument.Value is not PropertyState argument) continue;

			ApplyInputArguments(argument);
		}
	}

	protected void ApplyInputArguments(PropertyState argument)
	{
		var refs = new List<IReference>();

		argument.GetReferences(NodeManager.SystemContext, refs);

		var parentMethodState =
			GetNodeState<MethodState>(ExpandedNodeId.ToNodeId(refs[0].TargetId, NodeManager.Server.NamespaceUris));

		// Versuche, als Argument[] zu casten
		if (argument.Value is ExtensionObject[] extObjs)
		{
			var args = extObjs.Select(eo => eo.Body).OfType<Argument>().ToArray();

			var argumentState = new PropertyState<Argument[]>(parentMethodState)
			{
				NodeId = argument.NodeId,
				BrowseName = argument.BrowseName,
				DisplayName = argument.DisplayName,
				Description = argument.Description,
				TypeDefinitionId = VariableTypeIds.PropertyType,
				ReferenceTypeId = ReferenceTypeIds.HasProperty,
				DataType = DataTypeIds.Argument,
				ValueRank = ValueRanks.OneDimension,
				Value = args
			};

			if (argumentState.BrowseName == BrowseNames.InputArguments)
				parentMethodState.InputArguments = argumentState;
			else if (argumentState.BrowseName == BrowseNames.OutputArguments)
				parentMethodState.OutputArguments = argumentState;
		}
	}
}