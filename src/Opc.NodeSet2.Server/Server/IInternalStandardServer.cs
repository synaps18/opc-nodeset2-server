using System.Security.Cryptography.X509Certificates;
using Opc.Ua;
using Opc.Ua.Server;

namespace Opc.NodeSet2.Server.Server;

public interface IInternalStandardServer : ISessionServer
{
	internal InternalNodeManager? NodeManager { get; }

	void Dispose();
	EndpointDescriptionCollection GetEndpoints();
	ResponseHeader GetEndpoints(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection profileUris, out EndpointDescriptionCollection endpoints);
	void ScheduleIncomingRequest(IEndpointIncomingRequest request);
	void ReportAuditOpenSecureChannelEvent(string globalChannelId, EndpointDescription endpointDescription, OpenSecureChannelRequest request, X509Certificate2 clientCertificate, Exception exception);
	void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception);
	void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception);
	void CreateConnection(Uri url, int timeout);
	ServiceHost Start(ApplicationConfiguration configuration, params Uri[] baseAddresses);
	void Start(ApplicationConfiguration configuration);
	void Stop();
	ServiceHost CreateServiceHost(ServerBase server, params Uri[] addresses);
	void CreateServiceHostEndpoint(Uri endpointUri, EndpointDescriptionCollection endpoints, EndpointConfiguration endpointConfiguration, ITransportListener listener, ICertificateValidator certificateValidator);
	UserTokenPolicyCollection GetUserTokenPolicies(ApplicationConfiguration configuration, EndpointDescription description);
	IServiceMessageContext MessageContext { get; set; }
	ServiceResult ServerError { get; set; }
	IServerInternal CurrentInstance { get; }
	IEnumerable<INodeManagerFactory> NodeManagerFactories { get; }
	event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;
	ResponseHeader FindServers(RequestHeader requestHeader, string endpointUrl, StringCollection localeIds, StringCollection serverUris, out ApplicationDescriptionCollection servers);
	ResponseHeader FindServersOnNetwork(RequestHeader requestHeader, uint startingRecordId, uint maxRecordsToReturn, StringCollection serverCapabilityFilter, out DateTime lastCounterResetTime, out ServerOnNetworkCollection servers);
	ResponseHeader CreateSession(RequestHeader requestHeader, ApplicationDescription clientDescription, string serverUri, string endpointUrl, string sessionName, byte[] clientNonce, byte[] clientCertificate, double requestedSessionTimeout, uint maxResponseMessageSize, out NodeId sessionId, out NodeId authenticationToken, out double revisedSessionTimeout, out byte[] serverNonce, out byte[] serverCertificate, out EndpointDescriptionCollection serverEndpoints, out SignedSoftwareCertificateCollection serverSoftwareCertificates, out SignatureData serverSignature, out uint maxRequestMessageSize);
	ResponseHeader ActivateSession(RequestHeader requestHeader, SignatureData clientSignature, SignedSoftwareCertificateCollection clientSoftwareCertificates, StringCollection localeIds, ExtensionObject userIdentityToken, SignatureData userTokenSignature, out byte[] serverNonce, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader CloseSession(RequestHeader requestHeader, bool deleteSubscriptions);
	ResponseHeader Cancel(RequestHeader requestHeader, uint requestHandle, out uint cancelCount);
	ResponseHeader AddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader AddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader DeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader DeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader BrowseNext(RequestHeader requestHeader, bool releaseContinuationPoints, ByteStringCollection continuationPoints, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader TranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader RegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, out NodeIdCollection registeredNodeIds);
	ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister);
	ResponseHeader QueryFirst(RequestHeader requestHeader, ViewDescription view, NodeTypeDescriptionCollection nodeTypes, ContentFilter filter, uint maxDataSetsToReturn, uint maxReferencesToReturn, out QueryDataSetCollection queryDataSets, out byte[] continuationPoint, out ParsingResultCollection parsingResults, out DiagnosticInfoCollection diagnosticInfos, out ContentFilterResult filterResult);
	ResponseHeader QueryNext(RequestHeader requestHeader, bool releaseContinuationPoint, byte[] continuationPoint, out QueryDataSetCollection queryDataSets, out byte[] revisedContinuationPoint);
	ResponseHeader Read(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader HistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader Write(RequestHeader requestHeader, WriteValueCollection nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader HistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader Call(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader CreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader ModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader SetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader SetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos);
	ResponseHeader DeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader CreateSubscription(RequestHeader requestHeader, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, bool publishingEnabled, byte priority, out uint subscriptionId, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);
	ResponseHeader ModifySubscription(RequestHeader requestHeader, uint subscriptionId, double requestedPublishingInterval, uint requestedLifetimeCount, uint requestedMaxKeepAliveCount, uint maxNotificationsPerPublish, byte priority, out double revisedPublishingInterval, out uint revisedLifetimeCount, out uint revisedMaxKeepAliveCount);
	ResponseHeader SetPublishingMode(RequestHeader requestHeader, bool publishingEnabled, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader Publish(RequestHeader requestHeader, SubscriptionAcknowledgementCollection subscriptionAcknowledgements, out uint subscriptionId, out UInt32Collection availableSequenceNumbers, out bool moreNotifications, out NotificationMessage notificationMessage, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader Republish(RequestHeader requestHeader, uint subscriptionId, uint retransmitSequenceNumber, out NotificationMessage notificationMessage);
	ResponseHeader TransferSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, bool sendInitialValues, out TransferResultCollection results, out DiagnosticInfoCollection diagnosticInfos);
	ResponseHeader DeleteSubscriptions(RequestHeader requestHeader, UInt32Collection subscriptionIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos);
	void BeginPublish(IEndpointIncomingRequest request);
	void CompletePublish(IEndpointIncomingRequest request);
	ServerStatusDataType GetStatus();
	bool RegisterWithDiscoveryServer();
	void AddNodeManager(INodeManagerFactory nodeManagerFactory);
	void RemoveNodeManager(INodeManagerFactory nodeManagerFactory);
}