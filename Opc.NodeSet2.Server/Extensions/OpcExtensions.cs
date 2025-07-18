using Opc.Ua;
using Opc.Ua.Server;

namespace Opc.NodeSet2.Server.Extensions;

/// <summary>
///     Provides extension methods for working with OPC UA nodes and variable states.
/// </summary>
public static class OpcExtensions
{
	/// <summary>
	///     Publishes a new value to the specified variable state, updating its value, timestamp, and status code.
	/// </summary>
	/// <typeparam name="T">The type of the value to be published.</typeparam>
	/// <param name="variableState">The variable state to which the value will be published. Cannot be <see langword="null" />.</param>
	/// <param name="value">The new value to assign to the variable state.</param>
	/// <param name="systemContext">The system context used to clear change masks. Cannot be <see langword="null" />.</param>
	public static void Publish<T>(this BaseVariableState variableState, T value, ISystemContext systemContext)
	{
		variableState.Value = value;
		variableState.Timestamp = DateTime.UtcNow;
		variableState.StatusCode = StatusCodes.Good;
		variableState.ClearChangeMasks(systemContext, false);
	}

	/// <summary>
	///     Attempts to find a predefined node of the specified type in the node manager.
	/// </summary>
	/// <typeparam name="T">The expected type of the node to find.</typeparam>
	/// <param name="nodeManager">The <see cref="CustomNodeManager2" /> instance to search for the node.</param>
	/// <param name="nodeId">The <see cref="NodeId" /> of the node to locate.</param>
	/// <param name="nodeState">
	///     When this method returns, contains the node of type <typeparamref name="T" /> if found; otherwise, the default
	///     value
	///     for the type.
	/// </param>
	/// <returns>
	///     <see langword="true" /> if a predefined node of type <typeparamref name="T" /> is found; otherwise,
	///     <see
	///         langword="false" />
	///     .
	/// </returns>
	internal static bool FindPredefinedNode<T>(this CustomNodeManager2 nodeManager, NodeId nodeId, out T? nodeState)
	{
		if (nodeManager.FindPredefinedNode(nodeId, typeof(T)) is T
		    foundState)
		{
			nodeState = foundState;
			return true;
		}

		nodeState = default;
		return false;
	}
}